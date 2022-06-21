using Becerra.User;
using Becerra.User.Factories;
using Zenject;

namespace Becerra.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly DiContainer container;

        public UserFactory(DiContainer container)
        {
            this.container = container;
        }

        public T CreateUser<T>(string uniqueID) where T : IUser
        {
            return container.Instantiate<T>(new object[] { uniqueID }); ;
        }

        public IUser CreateUser(string uniqueID)
        {
            return CreateUser<User.User>(uniqueID);
        }
    }
}