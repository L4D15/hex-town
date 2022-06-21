using Becerra.Events;
using Becerra.Game.Events;

namespace Becerra.Game.Input
{
    public interface IGameTickerService
    {
        IEventService<TickEvent> OnTick { get; }
    }
}