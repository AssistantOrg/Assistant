using System;

namespace Rovecode.Assistant.Facade.Domain.Models
{
    public interface IImageSearchInfo
    {
        public Uri SourceLink { get; set; }

        public Uri HostLink { get; set; }

        public string Text { get; set; }

        public bool IsSave { get; set; }

        public IImageInfo SourceImage { get; set; }

        public IImageInfo ThumbnailImage { get; set; }
    }
}
