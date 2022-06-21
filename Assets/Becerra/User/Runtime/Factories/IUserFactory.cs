namespace Becerra.User.Factories
{
    public interface IUserFactory
    {
        IUser CreateUser(string uniqueID);
    }
}