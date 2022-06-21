using Becerra.User.Factories;
using Becerra.User.Services;

namespace Becerra.User
{
    public class User : IUser
    {
        public User(string uniqueID, IUserCurrenciesServiceFactory currenciesFactory)
        {
            this.UniqueID = uniqueID;
            this.Currencies = currenciesFactory.Create();
        }

        public string UniqueID { get; }
        public IUserCurrenciesService Currencies { get; }
    }
}