using Becerra.Events;

namespace Becerra.Currency.Events
{
    public class CurrencyCapacityChangedEvent : IEvent
    {
        public ICurrency Currency { get; }
        public int Delta { get; }
        public int TotalCapacity { get; }

        public CurrencyCapacityChangedEvent(ICurrency currency, int delta, int totalCapacity)
        {
            this.Currency = currency;
            this.Delta = delta;
            this.TotalCapacity = totalCapacity;
        }
    }
}