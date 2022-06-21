using Becerra.Events;
using Becerra.Events.Factories;
using Zenject;

namespace Becerra.Factories
{
    public class EventServiceFactory : IEventServiceFactory
    {
        private readonly DiContainer container;

        public EventServiceFactory(DiContainer container)
        {
            this.container = container;
        }

        public T Create<T, R>()
            where T : IEventService<R>
            where R : IEvent
        {
            return this.container.Instantiate<T>();
        }

        public IEventService<T> CreateForEvent<T>() where T : IEvent
        {
            return Create<EventService<T>, T>();
        }
    }
}