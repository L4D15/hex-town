using Becerra.Game.Input;
using Becerra.UnityAdapter.Output;
using Zenject;

namespace Becerra.UnityAdapter
{
    public class UnityAdapterInstaller : MonoInstaller<UnityAdapterInstaller>
    {
        public GameTickerService GameTickerService;

        public override void InstallBindings()
        {
            Container.Bind<IGameTickerService>().To<GameTickerService>().FromInstance(GameTickerService);
        }
    }
}