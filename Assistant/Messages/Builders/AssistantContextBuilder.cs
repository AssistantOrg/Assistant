using System;
using System.Collections.Generic;
using System.Linq;
using Assistant.Application.Builders;
using Assistant.Application.Exceptions;
using Assistant.Application.Extensions;
using Assistant.Facade.Application;
using Assistant.Facade.Configuration;
using Assistant.Messages.Contexts;

namespace Assistant.Messages.Builders
{
    public class AssistantContextBuilder : Builder<AssistantContext>
    {
        private string _text;

        public AssistantContextBuilder(IOptions options)
        {
            _value = new AssistantContext()
            {
                Options = options
            };
        }

        public AssistantContextBuilder SetText(string text)
        {
            _text = text;
            return this;
        }

        public AssistantContextBuilder SetExecuteCommandKey(IEnumerable<string> key)
        {
            _value.Message.ExcuteCommandKey = key;
            return this;
        }

        public override AssistantContext GetResult()
        {
            // create context
            if (string.IsNullOrEmpty(_text))
            {
                throw new AssistantException("in assistant context builder text is null or empty");
            }

            try
            {
                _value.Message.TextKey = _text.ToKey();

                _value.Message.ExcuteAssistantKey = _value.Options.ExecuteAssistantKeys
                    .ToList().Find(delegate (IEnumerable<string> e) {
                        if (_value.Message.TextKey.Count() < e.Count()) return false;

                        return e.SequenceEqual(_value.Message.TextKey.Take(e.Count()));
                    });

                _value.Message.CommandKey = _value.Message.TextKey.ToArray()
                    .Skip(_value.Message.ExcuteAssistantKey != null
                        ? _value.Message.ExcuteAssistantKey.ToArray().Length
                        : 0);
            }
            catch (AssistantException)
            {

            }
            catch (Exception)
            {
                throw;
            }

            // out context
            return _value;
        }
    }
}
