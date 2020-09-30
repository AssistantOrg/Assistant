using System;
using System.Collections.Generic;
using System.Linq;
using Rovecode.Assistant.Application.Builders;
using Rovecode.Assistant.Application.Exceptions;
using Rovecode.Assistant.Application.Helpers;
using Rovecode.Assistant.Domain.Messages;
using Rovecode.Assistant.Domain.Models;
using Rovecode.Assistant.Domain.Users;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Ferry.Contexts;
using Rovecode.Assistant.Persistence.Services.Users;

namespace Rovecode.Assistant.Tools.Builders
{
    public class CommandContextBuilder : Builder<ICommandContext>
    {
        public string Text { get; set; }

        public UserToken IdentifyToken { get; set; }

        private readonly IApplicationContext _appContext;

        public CommandContextBuilder(IApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public override ICommandContext Build()
        {
            var context = new CommandContext();

            try
            {
                context.AppContext = _appContext;

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
            ctx.Message = new ReceiveMessage();

            SetTextKey(ref ctx);
            SetExecuteKey(ref ctx);
            SetCommandKey(ref ctx);
        }

        private void SetUser(ref CommandContext ctx)
        {
            var indentityService = new UserIdentify(ctx.AppContext);

            ctx.User = indentityService.IdentifyAsync(IdentifyToken).Result;
        }

        private void SetTextKey(ref CommandContext ctx)
        {
            ctx.Message.TextKey = KeyHelper.ConvertToKey(Text);
        }

        private void SetExecuteKey(ref CommandContext ctx)
        {
            var textKey = ctx.Message.TextKey;
            ctx.Message.ExcuteAssistantKey = ctx.AppContext.Info.Application.ExecuteAssistantKeys
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
