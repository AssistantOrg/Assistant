using System;
using System.Collections.Generic;
using System.Linq;
using Rovecode.Assistant.Application.Builders;
using Rovecode.Assistant.Application.Exceptions;
using Rovecode.Assistant.Application.Helpers;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Builders
{
    public class CommandContextBuilder : Builder<ICommandContext>
    {
        public string Text { get; set; }

        public string Identifier { get; set; }

        public IApplicationContext AppContext { get; set; }

        public CommandContextBuilder()
        {

        }

        public override ICommandContext Build()
        {
            var context = new CommandContext();

            try
            {
                context.Configuration = AppContext;

                SetMessage(ref context);
                SetUser(ref context);
            }
            catch (AssistantException)
            {

            }
            catch (Exception)
            {
                throw;
            }

            return context;
        }

        private void SetMessage(ref CommandContext ctx)
        {
            SetTextKey(ref ctx);
            SetExecuteKey(ref ctx);
            SetCommandKey(ref ctx);
        }

        private void SetUser(ref CommandContext ctx)
        {

        }

        private void SetTextKey(ref CommandContext ctx)
        {
            ctx.Message.TextKey = KeyHelper.ConvertToKey(Text);
        }

        private void SetExecuteKey(ref CommandContext ctx)
        {
            var textKey = ctx.Message.TextKey;
            ctx.Message.ExcuteAssistantKey = ctx.Configuration.Info.Application.ExecuteAssistantKeys
                .ToList().Find(delegate (IEnumerable<string> e)
                {
                    if (textKey.Count() < e.Count())
                    {
                        return false;
                    }

                    return e.SequenceEqual(textKey.Take(e.Count()));
                });
        }

        private void SetCommandKey(ref CommandContext ctx)
        {
            ctx.Message.CommandKey = ctx.Message.TextKey.ToArray()
                .Skip(ctx.Message.ExcuteAssistantKey != null
                    ? ctx.Message.ExcuteAssistantKey.ToArray().Length
                    : 0);
        }
    }
}
