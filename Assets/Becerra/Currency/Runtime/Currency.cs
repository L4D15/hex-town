using Becerra.Currency.Events;
using Becerra.Events;
using Becerra.Events.Factories;

namespace Becerra.Currency
{
    public class Currency : ICurrency
    {
        private readonly IEventServiceFactory eventsFactory;

        public Currency(CurrencyType type, IEventServiceFactory eventsFactory)
        {
            this.Type = type;
            this.eventsFactory = eventsFactory;

            this.CreateEvents();
        }

        public CurrencyType Type { get; }

        public int Amount { get; private set; }

        public int Capacity { get; private set; }

        public void Add(int amount)
        {
            this.Amount = amount;

            if (this.Amount > this.Capacity)
            {
                this.Amount = this.Capacity;
            }

            this.AmountChanged?.Trigger(new CurrencyAmountChanged(this, amount, this.Amount));
        }

        public void Substract(int amount)
        {
            if (amount > this.Amount)
            {
                amount = this.Amount;
            }
            this.Amount -= amount;

            this.AmountChanged?.Trigger(new CurrencyAmountChanged(this, amount, this.Amount));
        }

        public void SetCapacity(int capacity)
        {
            int delta = capacity - this.Capacity;
            this.Capacity = capacity;

            this.CapacityChanged?.Trigger(new CurrencyCapacityChangedEvent(this, delta, this.Capacity));
        }

        #region Events

        public IEventService<CurrencyAmountChanged> AmountChanged { get; private set; }
        public IEventService<CurrencyCapacityChangedEvent> CapacityChanged { get; private set; }

        private void CreateEvents()
        {
            this.AmountChanged = eventsFactory.CreateForEvent<CurrencyAmountChanged>();
            this.CapacityChanged = eventsFactory.CreateForEvent<CurrencyCapacityChangedEvent>();
        }

        #endregion Events
    }
}