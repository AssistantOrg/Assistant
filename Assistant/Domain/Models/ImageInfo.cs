using System;
using System.Drawing;
using Rovecode.Assistant.Facade.Domain.Attachments;
using Rovecode.Assistant.Facade.Domain.Models;

namespace Rovecode.Assistant.Domain.Attachments
{
    public class ImageInfo : IImageInfo
    {
        public Uri Link { get; set; }

        public Size Resolution { get; set; }

        public int Size { get; set; }

        public string FileFormat { get; set; }
    }
}
