namespace Becerra.Events
{
    public interface IEventService
    {
        void AddListener(IEventListener<IEvent> listener);

        void RemoveListener(IEventListener<IEvent> listener);

        void Trigger(IEvent gameEvent);

        /// <summary>
        /// Resets the service to start as clean.
        /// </summary>
        void Reset();
    }

    /// <summary>
    /// Handles event triggering for the given game event.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEventService<T> : IEventService where T : IEvent
    {
        /// <summary>
        /// Adds a new listener for this event.
        /// </summary>
        /// <param name="listener"></param>
        void AddListener(IEventListener<T> listener);

        /// <summary>
        /// Removes a listener from this event.
        /// </summary>
        /// <param name="listener"></param>
        void RemoveListener(IEventListener<T> listener);

        /// <summary>
        /// Triggers this event, informing each listener that registered for this event.
        /// <param name="gameEvent"/>Event to trigger</param>
        /// </summary>
        void Trigger(T gameEvent);
    }
}