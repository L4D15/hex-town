namespace Becerra.User.Services
{
    public interface IUsersService
    {
        IUser CreateUser(string uniqueID);

        IUser GetCurrentUser(string uniqueID);
    }
}