using System;
using Rovecode.Assistant.Facade.Domain.Attachments;
using Rovecode.Assistant.Facade.Domain.Models;

namespace Rovecode.Assistant.Domain.Attachments
{
    public class ImageSearchInfo : IImageSearchInfo
    {
        public Uri SourceLink { get; set; }

        public Uri HostLink { get; set; }

        public string Text { get; set; }

        public bool IsSave { get; set; }

        public IImageInfo SourceImage { get; set; }

        public IImageInfo ThumbnailImage { get; set; }
    }
}
