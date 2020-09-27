using System;

namespace Rovecode.Assistant.Facade.Domain.Application
{
    public interface IApplicationBingInfo
    {
        public Uri Link { get; set; }
        public string Token { get; set; }
    }
}
