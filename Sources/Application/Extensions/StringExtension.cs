using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assistant.Application.Exceptions;

namespace Assistant.Application.Extensions
{
    public static class StringExtension
    {
        public static IEnumerable<string> ToKey(this string text)
        {
            if (text == string.Empty)
            {
                throw new AssistantException("key string is empty");
            }

            // format text and 
            text = text.ToLower();

            // remove not valid characters
            text = Regex.Replace(text, @"[^a-zа-я0-9 ]", "", RegexOptions.Multiline);

            // remove multy spaces
            text = Regex.Replace(text, @"\s+", " ", RegexOptions.Multiline);

            return text.Split(" ");
        }
    }
}
