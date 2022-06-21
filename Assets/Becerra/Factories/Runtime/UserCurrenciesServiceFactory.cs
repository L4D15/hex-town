using Becerra.Services.User;
using Becerra.User.Factories;
using Becerra.User.Services;
using Zenject;

namespace Becerra.Factories
{
    public class UserCurrenciesServiceFactory : IUserCurrenciesServiceFactory
    {
        private readonly DiContainer container;

        public UserCurrenciesServiceFactory(DiContainer container)
        {
            this.container = container;
        }

        public T Create<T>() where T : IUserCurrenciesService
        {
            return this.container.Instantiate<T>();
        }

        public IUserCurrenciesService Create()
        {
            return Create<UserCurrenciesService>();
        }
    }
}