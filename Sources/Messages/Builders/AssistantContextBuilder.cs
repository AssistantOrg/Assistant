using System;
using System.Collections.Generic;
using System.Linq;
using Assistant.Application.Exceptions;
using Assistant.Application.Extensions;
using Assistant.Facade.Application;
using Assistant.Messages.Contexts;

namespace Assistant.Messages.Builders
{
    public class AssistantContextBuilder : IBuilder<AssistantContext>
    {
        private readonly string _text;

        private IEnumerable<string> _executeAssistantKey = new string[] { };
        private IEnumerable<string> _executeCommandKey = new string[] { };

        public AssistantContextBuilder(string text)
        {
            _text = text;
        }

        public AssistantContextBuilder SetExecuteAssistantKey(IEnumerable<string> key)
        {
            _executeAssistantKey = key;
            return this;
        }

        public AssistantContextBuilder SetExecuteCommandKey(IEnumerable<string> key)
        {
            _executeCommandKey = key;
            return this;
        }

        public AssistantContext GetResult()
        {
            // create context
            var ctx = new AssistantContext();

            if (_text == string.Empty || _text == null)
            {
                throw new AssistantException("in assistant context builder text is null or empty");
            }

            try
            {
                ctx.Message.ExcuteAssistantKey = _executeAssistantKey;
                ctx.Message.ExcuteCommandKey = _executeCommandKey;
                ctx.Message.TextKey = _text.ToKey();
                ctx.Message.CommandKey = ctx.Message.TextKey.ToArray()
                    .Skip(ctx.Message.ExcuteAssistantKey.ToArray().Length);
            }
            catch (Exception ex)
            {
                // if value is bad and ast error return null 
                if (ex is AssistantException)
                {
                    // Console.WriteLine(ex.Message);
                    return null;
                }
                else
                {
                    throw ex;
                }
            }

            // out context
            return ctx;
        }
    }
}
