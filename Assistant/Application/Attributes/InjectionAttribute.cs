using System;

namespace Rovecode.Assistant.Application.Attributes
{
    [AttributeUsage(
        validOn: AttributeTargets.All,
        AllowMultiple = false)]
    public class InjectionAttribute : Attribute
    {
        public bool IsAuto { get; set; } = true;

        public InjectionAttribute()
        {

        }
    }
}
