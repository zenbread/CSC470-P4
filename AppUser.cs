namespace P3
{
    public class AppUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool isAuthenticated { get; set; }

        public AppUser(string User, string Pass, string First, string Last, string Email, bool Auth)
        {
            UserName = User;
            Password = Pass;
            FirstName = First;
            LastName = Last;
            EmailAddress = Email;
            isAuthenticated = Auth;
        }
    }
}
