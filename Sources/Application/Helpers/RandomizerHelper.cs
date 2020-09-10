using System;
using System.Collections.Generic;
using System.Linq;

namespace Assistant.Application.Helpers
{
    public static class RandomizerHelper
    {
        public static T ChooseRandomFromArray<T>(IEnumerable<T> array)
        {
            var arr = array.ToArray();
            return arr[new Random().Next(0, arr.Length)];
        }
    }
}
