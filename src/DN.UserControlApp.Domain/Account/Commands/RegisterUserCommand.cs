namespace DN.UserControlApp.Domain.Account.Commands
{
    public class RegisterUserCommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public RegisterUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
