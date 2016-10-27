using DN.UserControlApp.Domain.Account.Scopes;
using DN.UserControlApp.Domain.Account.ValueObjects;
using System;

namespace DN.UserControlApp.Domain.Account.Entities
{
    public class User
    {
        protected User() { }
        public User(string firstName, string email, string password)
        {
            UserId = Guid.NewGuid();
            FirstName = firstName;
            Email = email;
            Password = password;
            IsActive = true;
            UserRole = UserRole.Admin;
        }
        public Guid UserId { get; private set; }
        public string FirstName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool IsActive { get; private set; }
        public UserRole UserRole { get; private set; }

        public void Register()
        {
            if (this.RegisterUserIsValid())
                return;
        }

        public bool Authenticate(string email, string password)
        {
            return Email == email && Password == password;
        }

        public void ChangePassword()
        {

        }

        public void ResetPassword()
        {

        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Inactivate()
        {
            IsActive = false;
        }

        public override string ToString()
        {
            return Email;
        }

    }
}
