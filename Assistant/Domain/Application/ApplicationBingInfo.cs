using System;
using Rovecode.Assistant.Facade.Domain.Application;

namespace Rovecode.Assistant.Domain.Application
{
    public class ApplicationBingInfo : IApplicationBingInfo
    {
        public Uri Link { get; set; }
        public string Token { get; set; }
    }
}
