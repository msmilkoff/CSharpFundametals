namespace BashSoft.Exceptions
{
    using System;

    public class InvalidCommandException : Exception
    {
        private const string InvalidCommandMessage = "The command  is not valid.";

        public InvalidCommandException(string message)
            :base(message)
        {
        }

        public InvalidCommandException()
            :base(InvalidCommandMessage)
        {
        }
    }
}