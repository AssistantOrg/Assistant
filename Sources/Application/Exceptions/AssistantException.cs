using System;

namespace Assistant.Application.Exceptions
{
    public class AssistantException : Exception
    {
        public AssistantException() : base()
        {

        }

        public AssistantException(string message) : base(message)
        {

        }
    }
}
