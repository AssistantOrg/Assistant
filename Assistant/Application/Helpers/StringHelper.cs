using System;
using System.Linq;

namespace Rovecode.Assistant.Application.Helpers
{
    public static class StringHelper
    {
        private static Random random = new Random();

        public static string GenerateRandom(int length, string mask = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890")
        {
            return new string(Enumerable.Repeat(mask, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
