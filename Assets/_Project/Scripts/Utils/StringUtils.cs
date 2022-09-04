public static class StringUtils
{
    #region Currencies

    public const int THREE_DIGIT = 3;
    public const int SIX_DIGIT = 6;

    /// <summary>
    /// A currency converter for our values, It determines by value digit and convert into a currency format.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns>Returns K / M values by digit</returns>
    public static string ToCurrency(this float amount) // Float version
    {
        int length = $"{amount}".Length;

        return length switch
        {
            // If our value is more than six digit, show it as M => 3000000 would be 3M.
            > SIX_DIGIT => $"{amount: 0,,.##M}",

            // If our value is more than three digit, show it as K => 3000 would be 3K.
            > THREE_DIGIT => $"{amount: 0,.##K}",

            // As default return normal value.
            _ => $"{amount}"
        };
    }

    /// <summary>
    /// A currency converter for our values, It determines by value digit and convert into a currency format.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns>Returns K / M values by digit</returns>
    public static string ToCurrency(this int amount) // Int version
    {
        int length = $"{amount}".Length;

        return length switch
        {
            // If our value is more than six digit, show it as M => 3000000 would be 3M.
            > SIX_DIGIT => $"{amount: 0,,.##M}",

            // If our value is more than three digit, show it as K => 3000 would be 3K.
            > THREE_DIGIT => $"{amount: 0,.##K}",

            // As default return normal value.
            _ => $"{amount}"
        };
    }

    #endregion
}