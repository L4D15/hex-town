using Becerra.Events.Factories;
using Becerra.Events.Tests.Events;

namespace Becerra.Events.Tests
{
    public class HealthService
    {
        public readonly IEventService<HealthRestoredEvent> OnHealthRestored;
        public readonly IEventService<HealthLostEvent> OnHealthLost;

        public HealthService(IEventServiceFactory eventFactory)
        {
            this.OnHealthRestored = eventFactory.CreateForEvent<HealthRestoredEvent>();
            this.OnHealthLost = eventFactory.CreateForEvent<HealthLostEvent>();
        }

        public void AddHealth(int amount)
        {
            this.OnHealthRestored.Trigger(new HealthRestoredEvent(amount));
        }

        public void RemoveHealth(int amount)
        {
            this.OnHealthLost.Trigger(new HealthLostEvent(amount));
        }
    }
}