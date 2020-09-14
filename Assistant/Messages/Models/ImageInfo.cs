using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Assistant.Messages.Models
{
    public class ImageInfo
    {
        public Uri Link { get; set; }

        public Size ExtensionSize { get; set; }

        public int FileSize { get; set; }

        public string FileFormat { get; set; }
    }
}
