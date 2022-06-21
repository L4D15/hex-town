using System.Collections.Generic;

namespace Becerra.Events
{
    public class EventService<TEvent> : IEventService<TEvent> where TEvent : IEvent
    {
        private readonly List<IEventListener<TEvent>> _listeners;
        private readonly List<IEventListener<TEvent>> _listenersToAdd;
        private readonly List<IEventListener<TEvent>> _listenersToRemove;
        private bool _isTriggering;

        public EventService()
        {
            this._listeners = new List<IEventListener<TEvent>>();
            this._listenersToAdd = new List<IEventListener<TEvent>>();
            this._listenersToRemove = new List<IEventListener<TEvent>>();
        }

        public void AddListener(IEventListener<TEvent> listener)
        {
            if (listener == null) return;

            if (this._isTriggering)
            {
                AddDeferred(listener);
            }
            else
            {
                AddNow(listener);
            }
        }

        public void RemoveListener(IEventListener<TEvent> listener)
        {
            if (listener == null) return;

            if (this._isTriggering)
            {
                RemoveDeferred(listener);
            }
            else
            {
                RemoveNow(listener);
            }

            this._listeners.Remove(listener);
        }

        public void AddListener(IEventListener<IEvent> listener)
        {
            AddListener(listener as IEventListener<TEvent>);
        }

        public void RemoveListener(IEventListener<IEvent> listener)
        {
            RemoveListener(listener as IEventListener<TEvent>);
        }

        public void Trigger(TEvent gameEvent)
        {
            if (gameEvent == null) return;
            this._isTriggering = true;

            this._listeners.ForEach(l => l.HandleEvent(gameEvent));

            this._isTriggering = false;

            AddDeferredListeners();
            RemoveDeferredListeners();
        }

        public void Trigger(IEvent gameEvent)
        {
            Trigger((TEvent)gameEvent);
        }

        public void Reset()
        {
            this._listeners.Clear();
            this._listenersToAdd.Clear();
            this._listenersToRemove.Clear();
        }

        private void AddNow(IEventListener<TEvent> listener)
        {
            if (this._listeners.Contains(listener)) return;

            this._listeners.Add(listener);
        }

        private void RemoveNow(IEventListener<TEvent> listener)
        {
            this._listeners.Remove(listener);
        }

        private void AddDeferred(IEventListener<TEvent> listener)
        {
            this._listenersToAdd.Add(listener);
        }

        private void RemoveDeferred(IEventListener<TEvent> listener)
        {
            this._listenersToRemove.Add(listener);
        }

        private void AddDeferredListeners()
        {
            foreach (var listener in this._listenersToAdd)
            {
                AddNow(listener);
            }

            this._listenersToAdd.Clear();
        }

        private void RemoveDeferredListeners()
        {
            foreach (var listener in this._listenersToRemove)
            {
                RemoveNow(listener);
            }

            this._listenersToRemove.Clear();
        }
    }
}