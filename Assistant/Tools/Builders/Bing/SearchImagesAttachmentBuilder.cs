using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rovecode.Assistant.Application.Builders;
using Rovecode.Assistant.Application.Exceptions;
using Rovecode.Assistant.Application.Extensions;
using Rovecode.Assistant.Domain.Attachments;
using Rovecode.Assistant.Facade.Domain.Attachments;
using Rovecode.Assistant.Facade.Domain.Models;
using Rovecode.Assistant.Facade.Enums;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Builders.Bing
{
    public class SearchImagesAttachmentBuilder : ContextBuilder<IImagesAttachment>
    {
        private IEnumerable<string> _searchKey;

        public int Count { get; set; } = 5;
        public int Offset { get; set; } = 0;

        public int MaxImageFileSize { get; set; } = int.MaxValue;
        public int MinImageFileSize { get; set; } = 0;

        public Size MinImageExtensionSize { get; set; } = new Size(0, 0);
        public Size MaxImageExtensionSize { get; set; } = new Size(int.MaxValue, int.MaxValue);

        public SafeSearch SafeSearch { get; set; } = SafeSearch.Selective;

        public ImageLicense ImageLicense { get; set; } = ImageLicense.All;
        public ImageType ImageType { get; set; } = ImageType.Photo;

        public SearchImagesAttachmentBuilder(ICommandContext context)
            : base(context)
        {
            if (context.AppContext.Info.Bing == null)
            {
                throw new AssistantException("bing data is null or empty");
            }
        }

        private string SafeSearchToBingSaveSearchString(SafeSearch safeSearch)
        {
            switch (safeSearch)
            {
                case SafeSearch.Off:
                    return "Off";
                case SafeSearch.Selective:
                    return "Moderate";
                case SafeSearch.Strict:
                    return "Strict";
                default:
                    return SafeSearchToBingSaveSearchString(SafeSearch.Selective);
            }
        }

        private string ImageLicenseToBingImageLicenseString(ImageLicense imageLicense)
        {
            switch (imageLicense)
            {
                case ImageLicense.All:
                    return "All";
                case ImageLicense.Any:
                    return "All";
                case ImageLicense.Modify:
                    return "All";
                case ImageLicense.Share:
                    return "All";
                case ImageLicense.Public:
                    return "Public";
                default:
                    return ImageLicenseToBingImageLicenseString(ImageLicense.Any);
            }
        }

        private string ImageTypeToBingImageTypeString(ImageType imageType)
        {
            switch (imageType)
            {
                case ImageType.Gifs:
                    return "AnimatedGif";
                case ImageType.Photo:
                    return "Photo";
                case ImageType.Transparent:
                    return "Transparent";
                default:
                    return ImageTypeToBingImageTypeString(ImageType.Photo);
            }
        }

        private Uri BuildRequestUri()
        {
            var link = new Uri(_context.AppContext.Info.Bing.Link + "/bing/v7.0/images/search");

            link = link.AddQuery("q", string.Join("+", _searchKey));

            link = link.AddQuery("count", Count.ToString());
            link = link.AddQuery("offset", Offset.ToString());

            link = link.AddQuery("maxFileSize", MaxImageFileSize.ToString());
            link = link.AddQuery("minFileSize", MinImageFileSize.ToString());

            link = link.AddQuery("minWidth", MinImageExtensionSize.Width.ToString());
            link = link.AddQuery("minHeight", MinImageExtensionSize.Height.ToString());

            link = link.AddQuery("maxWidth", MaxImageExtensionSize.Width.ToString());
            link = link.AddQuery("maxHeight", MaxImageExtensionSize.Height.ToString());

            link = link.AddQuery("license", ImageLicenseToBingImageLicenseString(ImageLicense));

            link = link.AddQuery("safeSearch", SafeSearchToBingSaveSearchString(SafeSearch));

            link = link.AddQuery("imageType", ImageTypeToBingImageTypeString(ImageType));

            link = link.AddQuery("cc", _context.AppContext.Info.Application.TargetLanguage);
            link = link.AddQuery("setLang", _context.AppContext.Info.Application.TargetLanguage);

            return link;
        }

        private async Task<IEnumerable<IImageSearchInfo>> BuildAndSendHttpResuest()
        {
            var link = BuildRequestUri();

            var str = link.ToString();

            var client = new HttpClient();

            client.DefaultRequestHeaders
                .Add("Ocp-Apim-Subscription-Key", _context.AppContext.Info.Bing.Token);

            var result = await client.GetAsync(link);

            var json = JsonConvert.DeserializeObject<Dictionary<string, object>>(
                await result.Content.ReadAsStringAsync());

            var value = (JArray)json["value"];

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return value.Select(e => new ImageSearchInfo
                {
                    Text = (string)e["name"],
                    SourceLink = new Uri((string)e["webSearchUrl"]),
                    HostLink = new Uri((string)e["hostPageUrl"]),
                    IsSave = (bool)e["isFamilyFriendly"],
                    SourceImage = new ImageInfo
                    {
                        Link = new Uri((string)e["contentUrl"]),
                        FileFormat = (string)e["encodingFormat"],
                        Resolution = new Size((int)e["width"], (int)e["height"]),
                    },
                    ThumbnailImage = new ImageInfo
                    {
                        Link = new Uri((string)e["thumbnailUrl"]),
                        FileFormat = (string)e["encodingFormat"],
                        Resolution = new Size((int)e["thumbnail"]["width"], (int)e["thumbnail"]["height"]),
                    }
                });
            }
            else
            {
                throw new AssistantException("http return bad code (not 200)");
            }
        }

        public override IImagesAttachment Build()
        {
            var result = BuildAndSendHttpResuest();

            result.Wait(TimeSpan.FromSeconds(3));

            if (!result.IsCompletedSuccessfully)
            {
                throw new AssistantException("http request to the bing server canseled with error");
            }

            return new ImagesAttachment
            {
                Images = result.Result,
                Source = WebSource.Bing,
            };
        }
    }
}
