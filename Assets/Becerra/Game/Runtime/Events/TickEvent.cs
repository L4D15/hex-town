using Becerra.Events;

namespace Becerra.Game.Events
{
    public class TickEvent : IEvent
    {
        public float DeltaTime { get; }

        public TickEvent(float deltaTime)
        {
            this.DeltaTime = deltaTime;
        }
    }
}