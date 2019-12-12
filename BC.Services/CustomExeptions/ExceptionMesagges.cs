namespace BC.Services.CustomExeptions
{
    public static class ExceptionMessages
    {
        public const string InvalidModelState = "Invalid Model State!";
        public const string OddsCannotBeUnderOne = "Odds values cannot be smaller than 1.00!";
        public const string RestrictedSymbols = "Symbols \">\" and \"<\" are prohibited!";
        public const string ContextNull = "BettingContext cannot be null!";
        public const string PreviewModeServiceNull = "PreviewModeService cannot be null!";
        public const string EditModeServiceContextNull = "EditModeServiceContext cannot be null!";
        public const string ToastNull = "Toast cannot be null!";
    }
}
