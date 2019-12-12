using System;

namespace BC.Services.CustomExeptions
{
    public class BetExeption : Exception
    {
        public BetExeption()
        {
        }

        public BetExeption(string message)
            : base(message)
        {
        }

    }
}
