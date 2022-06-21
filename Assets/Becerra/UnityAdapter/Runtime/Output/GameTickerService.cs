using Becerra.Events;
using Becerra.Events.Factories;
using Becerra.Game.Events;
using Becerra.Game.Input;
using UnityEngine;
using Zenject;

namespace Becerra.UnityAdapter.Output
{
    public class GameTickerService : MonoBehaviour, IGameTickerService
    {
        public IEventService<TickEvent> OnTick { get; private set; }

        [Inject]
        public void InjectDependencies(IEventServiceFactory eventsFactory)
        {
            this.OnTick = eventsFactory.CreateForEvent<TickEvent>();
        }
    }
}