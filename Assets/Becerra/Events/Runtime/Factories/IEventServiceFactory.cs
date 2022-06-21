using Zenject;

namespace Becerra.Events.Factories
{
    public interface IEventServiceFactory
    {
        /// <summary>
        /// Creates a new service to handle event triggering for a type of event.
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <returns></returns>
        IEventService<T> CreateForEvent<T>() where T : IEvent;
    }
}