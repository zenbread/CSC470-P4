using System.Collections.Generic;

namespace P3
{
    public class FakeAppUserRepository : IAppUserRepository
    {
        private static Dictionary<string, AppUser> Users;

        public FakeAppUserRepository()
        {
            if (Users == null)
            {
                Users = new Dictionary<string, AppUser>();
                AppUser user1 = new AppUser(
                    "Steve1234",
                    "Billy",
                    "Steve",
                    "Davies",
                    "Steve1234@aol.com",
                    false
                );
                Users.Add(user1.UserName, user1);
            }
        }

        public List<AppUser> GetAll()
        {
            List<AppUser> users = new List<AppUser>();
            foreach (KeyValuePair<string, AppUser> user in Users)
            {
                users.Add(user.Value);
            }
            return users;
        }

        public AppUser GetByUserName(string UserName)
        {
            AppUser user;
            Users.TryGetValue(UserName, out user);
            return user;
        }

        public bool Login(string UserName, string Password)
        {
            AppUser user = GetByUserName(UserName);
            if (user != null)
            {
                if (Password == user.Password)
                {
                    SetAuthentication(UserName, true);
                    return true;
                }
                else
                {
                    SetAuthentication(UserName, false);
                }
            }
            return false;
        }

        public void SetAuthentication(string UserName, bool IsAuthenticated)
        {
            AppUser user = GetByUserName(UserName);
            if (user != null)
            {
                user.isAuthenticated = IsAuthenticated;
            }
        }
    }
}
