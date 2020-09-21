using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Assistant.Application.Builders;
using Assistant.Application.Exceptions;
using Assistant.Application.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        private int _count = 5;
        private int _offset = 0;

        private int _maxImageFileSize = int.MaxValue;
        private int _minImageFileSize = 0;

        private Size _minImageExtensionSize = new Size(0, 0);
        private Size _maxImageExtensionSize = new Size(int.MaxValue, int.MaxValue);

        private SafeSearch _safeSearch = SafeSearch.Selective;

        private ImageLicense _imageLicense = ImageLicense.All;
        private ImageType _imageType = ImageType.Photo;

        public SearchImagesAttachmentBuilder(IAssistantContext context)
            : base(context)
        {
            if (context.Configuration.Info.Bing == null)
            {
                throw new AssistantException("bing data is null or empty");
            }

            _value = new ImagesAttachment()
            {
                Source = Facade.Enums.WebSource.Bing
            };
        }

        public SearchImagesAttachmentBuilder SetSearchKey(IEnumerable<string> searchKey)
        {
            _searchKey = searchKey;
            return this;
        }

        public SearchImagesAttachmentBuilder SetOffset(int offset)
        {
            _offset = offset;
            return this;
        }

        public SearchImagesAttachmentBuilder SetCount(int count)
        {
            _count = count;
            return this;
        }

        public SearchImagesAttachmentBuilder SetSafeSearch(SafeSearch type)
        {
            _safeSearch = type;
            return this;
        }


        public SearchImagesAttachmentBuilder SetImageLicense(ImageLicense license)
        {
            _imageLicense = license;
            return this;
        }

        public SearchImagesAttachmentBuilder SetImageType(ImageType type)
        {
            _imageType = type;
            return this;
        }

        public SearchImagesAttachmentBuilder SetImageFileMaxSize(int size)
        {
            _maxImageFileSize = size;
            return this;
        }

        public SearchImagesAttachmentBuilder SetImageFileMinSize(int size)
        {
            _minImageFileSize = size;
            return this;
        }

        public SearchImagesAttachmentBuilder SetImageExtensionMaxSize(Size size)
        {
            _maxImageExtensionSize = size;
            return this;
        }

        public SearchImagesAttachmentBuilder SetImageExtensionMinSize(Size size)
        {
            _minImageExtensionSize = size;
            return this;
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
            var link = new Uri(_context.Configuration.Info.Bing.Link + "/bing/v7.0/images/search");

            link = link.AddQuery("q", string.Join("+", _searchKey));

            link = link.AddQuery("count", _count.ToString());
            link = link.AddQuery("offset", _offset.ToString());

            link = link.AddQuery("maxFileSize", _maxImageFileSize.ToString());
            link = link.AddQuery("minFileSize", _minImageFileSize.ToString());

            link = link.AddQuery("minWidth", _minImageExtensionSize.Width.ToString());
            link = link.AddQuery("minHeight", _minImageExtensionSize.Height.ToString());

            link = link.AddQuery("maxWidth", _maxImageExtensionSize.Width.ToString());
            link = link.AddQuery("maxHeight", _maxImageExtensionSize.Height.ToString());

            link = link.AddQuery("license", ImageLicenseToBingImageLicenseString(_imageLicense));

            link = link.AddQuery("safeSearch", SafeSearchToBingSaveSearchString(_safeSearch));

            link = link.AddQuery("imageType", ImageTypeToBingImageTypeString(_imageType));

            link = link.AddQuery("cc", _context.Configuration.Info.Application.TargetLanguage);
            link = link.AddQuery("setLang", _context.Configuration.Info.Application.TargetLanguage);

            return link;
        }

        private async Task<IEnumerable<IImageSearchInfo>> BuildAndSendHttpResuest()
        {
            var link = BuildRequestUri();

            var str = link.ToString();

            var client = new HttpClient();

            client.DefaultRequestHeaders
                .Add("Ocp-Apim-Subscription-Key", _context.Configuration.Info.Bing.Token);

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

        public override IImagesAttachment Result()
        {
            var result = BuildAndSendHttpResuest();
            result.Wait(TimeSpan.FromSeconds(3));

            if (result.IsCompletedSuccessfully)
            {
                _value.Images = result.Result;
            }
            else
            {
                throw new AssistantException("http request to the bing server canseled with error");
            }

            return _value;
        }
    }
}
