using DN.UserControlApp.Domain.Account.Scopes;
using System;

namespace DN.UserControlApp.Domain.Account.Entities
{
    public class User 
    {
        protected User() { }
        public User(string userName, string password)
        {
            UserId = Guid.NewGuid();
            UserName = userName;
            Password = password;
            IsActive = true;
            CreateDate = DateTime.Now;
        }
        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool IsActive { get; private set; }

        public void Register()
        {
            if (this.RegisterUserIsValid())
                return;
        }

        public override string ToString()
        {
            return UserName;
        }

    }
}
