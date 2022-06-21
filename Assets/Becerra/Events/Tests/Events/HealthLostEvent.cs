namespace Becerra.Events.Tests.Events
{
    public class HealthLostEvent : IEvent
    {
        public int Amount { get; }

        public HealthLostEvent(int amount)
        {
            this.Amount = amount;
        }
    }
}