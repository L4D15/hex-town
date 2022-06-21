using Becerra.Currency.Events;
using Becerra.Events;

namespace Becerra.Currency
{
    public interface ICurrency
    {
        CurrencyType Type { get; }
        int Amount { get; }
        int Capacity { get; }

        IEventService<CurrencyAmountChanged> AmountChanged { get; }
        IEventService<CurrencyCapacityChangedEvent> CapacityChanged { get; }

        void Add(int amount);

        void Substract(int amount);

        void SetCapacity(int capacity);
    }
}