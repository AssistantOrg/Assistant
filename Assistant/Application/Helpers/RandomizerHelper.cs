using System;
using System.Collections.Generic;
using System.Linq;
using Rovecode.Assistant.Application.Exceptions;

namespace Rovecode.Assistant.Application.Helpers
{
    public static class RandomizerHelper
    {
        public static T ChooseRandomFromArray<T>(IEnumerable<T> array)
        {
            if (array == null || array.Count() == 0)
            {
                throw new AssistantException("array shoud be not null and contains value(s)");
            }

            var arr = array.ToArray();
            return arr[new Random().Next(0, arr.Length)];
        }
    }
}
