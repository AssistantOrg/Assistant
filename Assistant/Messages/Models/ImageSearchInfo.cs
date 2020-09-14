using System;

namespace Assistant.Messages.Models
{
    public class ImageSearchInfo
    {
        public Uri SourceLink { get; set; }

        public Uri HostLink { get; set; }

        public string Text { get; set; }

        public bool IsSave { get; set; } = true;

        public ImageInfo SourceImage { get; set; }

        public ImageInfo ThumbnailImage { get; set; }
    }
}
