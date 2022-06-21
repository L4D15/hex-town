using Becerra.Events;
using Becerra.Game.Events;
using Becerra.Game.Input;
using Becerra.Game.Output;
using Becerra.User.Services;

namespace Becerra.Game
{
    public class GameService : IGameService, IEventListener<TickEvent>
    {
        private readonly IGameTickerService tickerService;

        public GameService(
            IGameTickerService tickerService,
            IUsersService usersService)
        {
            this.tickerService = tickerService;
            this.UsersService = usersService;
        }

        public bool IsPlaying { get; private set; }
        public IUsersService UsersService { get; private set; }

        public void Pause()
        {
            this.IsPlaying = false;

            this.tickerService.OnTick.RemoveListener(this);
        }

        public void Resume()
        {
            this.IsPlaying = true;

            this.tickerService.OnTick.AddListener(this);
        }

        public void HandleEvent(TickEvent gameEvent)
        {
            // TODO: Tick all other systems
        }
    }
}