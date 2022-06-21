using Becerra.Currency.Factories;
using Becerra.Events.Factories;
using Becerra.User.Factories;
using Zenject;

namespace Becerra.Factories
{
    public class FactoriesInstaller : Installer<FactoriesInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICurrencyFactory>().To<CurrencyFactory>().AsSingle();
            Container.Bind<IEventServiceFactory>().To<EventServiceFactory>().AsSingle();
            Container.Bind<IUserFactory>().To<UserFactory>().AsSingle();
            Container.Bind<IUserCurrenciesServiceFactory>().To<UserCurrenciesServiceFactory>().AsSingle();
        }
    }
}