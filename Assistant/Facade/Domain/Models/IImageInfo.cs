using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Rovecode.Assistant.Facade.Domain.Models
{
    public interface IImageInfo
    {
        public Uri Link { get; set; }

        public Size Resolution { get; set; }

        public int Size { get; set; }

        public string FileFormat { get; set; }
    }
}
