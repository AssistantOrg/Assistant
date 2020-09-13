using System.ComponentModel.DataAnnotations;
using Assistant.Facade.Messages;

namespace Assistant.Messages
{
    public class AssistantMessage : IAssistantMessage
    {
        //[Required]
        public string Text { get; set; }

        public IAttachment Attachment { get; set; }
    }
}
