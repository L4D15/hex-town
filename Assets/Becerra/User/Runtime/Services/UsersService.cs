using Becerra.User.Factories;
using System.Collections.Generic;

namespace Becerra.User.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserFactory userFactory;
        private readonly Dictionary<string, IUser> users;

        public UsersService(IUserFactory userFactory)
        {
            this.userFactory = userFactory;
            this.users = new Dictionary<string, IUser>();
        }

        public IUser CreateUser(string uniqueID)
        {
            var user = this.userFactory.CreateUser(uniqueID);

            return user;
        }

        public IUser GetCurrentUser(string uniqueID)
        {
            IUser user;

            if (this.users.TryGetValue(uniqueID, out user) == false)
            {
                user = null;
            }

            return user;
        }
    }
}