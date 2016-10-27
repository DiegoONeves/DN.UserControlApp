namespace DN.UserControlApp.Domain.Account.Commands
{
    public class UpdateUserCommand
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public UpdateUserCommand(string firstName, string email, bool isActive)
        {
            FirstName = firstName;
            Email = email;
            IsActive = isActive; 
        }
    }
}
