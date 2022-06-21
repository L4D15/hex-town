using Becerra.User.Services;

namespace Becerra.User
{
    public interface IUser
    {
        string UniqueID { get; }
        IUserCurrenciesService Currencies { get; }
    }
}