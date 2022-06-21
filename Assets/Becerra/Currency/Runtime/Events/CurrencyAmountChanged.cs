using Becerra.Events;

namespace Becerra.Currency.Events
{
    public class CurrencyAmountChanged : IEvent
    {
        public ICurrency Currency { get; }
        public int Delta { get; }
        public int TotalAmount { get; }

        public CurrencyAmountChanged(ICurrency currency, int delta, int totalAmount)
        {
            this.Currency = currency;
            this.Delta = delta;
            this.TotalAmount = totalAmount;
        }
    }
}