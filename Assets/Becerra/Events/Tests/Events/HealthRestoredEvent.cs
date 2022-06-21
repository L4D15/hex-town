namespace Becerra.Events.Tests.Events
{
    public class HealthRestoredEvent : IEvent
    {
        public int Amount { get; }

        public HealthRestoredEvent(int amount)
        {
            this.Amount = amount;
        }
    }
}