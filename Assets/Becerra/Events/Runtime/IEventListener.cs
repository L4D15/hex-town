namespace Becerra.Events
{
    /// <summary>
    /// Listens to an event and handles what to do when receiving it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEventListener<T> where T : IEvent
    {
        void HandleEvent(T gameEvent);
    }
}