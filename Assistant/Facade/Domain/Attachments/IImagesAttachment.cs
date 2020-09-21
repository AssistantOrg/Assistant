using System;
using System.Collections.Generic;
using Rovecode.Assistant.Facade.Domain.Models;

namespace Rovecode.Assistant.Facade.Domain.Attachments
{
    public interface IImagesAttachment : IWebSourceAttachment
    {
        public IEnumerable<IImageSearchInfo> Images { get; set; }
    }
}
