using System;

namespace Rovecode.Assistant.Application.Attributes
{
    public class InjectionAttribute : Attribute
    {
        public bool IsAuto { get; set; } = true;

        public InjectionAttribute()
        {

        }
    }
}
