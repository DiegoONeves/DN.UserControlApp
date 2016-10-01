namespace DN.UserControlApp.Domain.Account.Commands
{
    public class RegisterUserCommand
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterUserCommand(string firstName, string email, string password)
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }
    }
}
