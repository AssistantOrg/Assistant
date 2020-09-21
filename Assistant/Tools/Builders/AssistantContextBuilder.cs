using System;
using System.Collections.Generic;
using System.Linq;
using Assistant.Application.Builders;
using Assistant.Application.Exceptions;
using Assistant.Application.Extensions;
using Rovecode.Assistant.Application.Helpers;
using Rovecode.Assistant.Facade.Application.Configurations;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Builders
{
    public class AssistantContextBuilder : Builder<IAssistantContext>
    {
        private string _text;

        public AssistantContextBuilder(IConfiguration configuration)
        {
            _value = new AssistantContext()
            {
                Configuration = configuration
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

        public override IAssistantContext Result()
        {
            if (string.IsNullOrEmpty(_text))
            {
                throw new AssistantException("in assistant context builder text is null or empty");
            }

            try
            {
                _value.Message.TextKey = KeyHelper.ConvertToKey(_text);

                _value.Message.ExcuteAssistantKey = _value.Configuration.Info.Application.ExecuteAssistantKeys
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

            return _value;
        }
    }
}
