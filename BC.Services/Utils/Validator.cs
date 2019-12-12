using BC.Services.CustomExeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BC.Services.Utils
{
    public static class Validator
    {
        public static void ValidateIfNull(this object value, string msg = null)
        {
            if (msg == null)
            {
                msg = "Value cannot be null!";
            }

            if (value == null)
            {
                throw new BetException(msg);
            }
            if (value.ToString().Contains('>') || value.ToString().Contains('<'))
            {
                throw new BetException(ExceptionMessages.RestrictedSymbols);
            }
        }

        public static void ValidateOdds(this string value, string msg = null)
        {
            if (msg == null)
            {
                msg = "Invalid Odds parameter!";
            }
            if (value == null)
            {
                throw new BetException(msg);
            }
            try
            {
                var odd = double.Parse(value);
                if (odd < 1.0)
                {
                    throw new BetException(ExceptionMessages.OddsCannotBeUnderOne);
                }
            }
            catch (Exception)
            {
                throw new BetException(msg);
            }
        }
    }
}
