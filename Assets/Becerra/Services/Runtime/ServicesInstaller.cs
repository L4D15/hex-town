using Becerra.User.Services;
using Zenject;

namespace Becerra.Services
{
    public class ServicesInstaller : Installer<ServicesInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IUsersService>().To<UsersService>().AsSingle();
        }
    }
}