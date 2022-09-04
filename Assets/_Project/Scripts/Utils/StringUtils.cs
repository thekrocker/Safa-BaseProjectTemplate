public static class StringUtils
{
    public static string ToCurrency(this float amount)
    {
        int length = $"{amount}".Length;

        return length switch
        {
            > 6 => $"{amount: 0,,.##M}",
            > 2 => $"{amount: 0,.##K}",
            _ => $"{amount}"
        };
    }
}