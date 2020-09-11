using System;
using System.ComponentModel.DataAnnotations;

namespace Assistant.Messages.Models
{
    public class ImageModel
    {
        public Uri SourceLink { get; set; }

        //[Required]
        public Uri ImageLink { get; set; }
        public Uri ThumbnailLink { get; set; }

        public string Text { get; set; }
    }
}
