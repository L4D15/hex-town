namespace Becerra.Currency
{
    using System.Text;

    public static class CurrencyUtils
    {
        public static string ToDeltaFormat(CurrencyType type, int amount)
        {
            var text = new StringBuilder();

            if (amount > 0)
            {
                text.Append("+");
            }

            text.Append(amount.ToString("N0"));

            return text.ToString();
        }
    }
}