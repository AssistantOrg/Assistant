using System;
using System.Collections.Generic;
using Rovecode.Assistant.Facade.Domain.Attachments;
using Rovecode.Assistant.Facade.Domain.Models;

namespace Rovecode.Assistant.Domain.Attachments
{
    public class ImagesAttachment : WebSourceAttachment, IImagesAttachment
    {
        public IEnumerable<IImageSearchInfo> Images { get; set; }
    }
}
