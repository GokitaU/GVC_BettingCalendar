using System;

namespace BC.Services.CustomExeptions
{
    public class BetException : Exception
    {
        public BetException()
        {
        }

        public BetException(string message)
            : base(message)
        {
        }

    }
}
