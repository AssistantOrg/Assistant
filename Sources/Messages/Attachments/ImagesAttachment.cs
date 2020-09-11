using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Assistant.Messages.Enums;
using Assistant.Messages.Models;

namespace Assistant.Messages.Attachments
{
    public class ImagesAttachment : WebSourceAttachment
    {
        //[Required]
        public IEnumerable<ImageModel> Images { get; set; }
    }
}
