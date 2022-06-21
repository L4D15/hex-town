using Zenject;
using UnityEngine;
using Becerra.Factories;
using Becerra.Game.Output;
using Becerra.User.Services;

namespace Becerra.Game
{
    [CreateAssetMenu(fileName = "GameInstaller", menuName = "Becerra/Installers/Game")]
    public class GameInstaller : ScriptableObjectInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            FactoriesInstaller.Install(Container);

            Container.Bind<IGameService>().To<GameService>().AsSingle();
            Container.Bind<IUsersService>().To<UsersService>().AsSingle();
        }
    }
}