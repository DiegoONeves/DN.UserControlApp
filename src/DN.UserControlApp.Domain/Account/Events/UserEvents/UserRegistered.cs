using DN.UserControlApp.Domain.Account.Entities;
using DN.UserControlApp.SharedKernel.Events.Contracts;
using System;

namespace DN.UserControlApp.Domain.Account.Events.UserEvents
{
    public class UserRegistered : IDomainEvent
    {
        public DateTime DateOccurred { get; private set; }
        public User UserCreated { get; private set; }
        public string EmailTitle { get; private set; }
        public string EmailBody { get; private set; }

        public UserRegistered(User user, DateTime dateOccured)
        {
            UserCreated = user;
            DateOccurred = DateTime.Now;
            EmailTitle = "Seja bem vindo " + user.Email;
            EmailBody = "Obrigado por se cadastrar.";
        }

        public UserRegistered(User user) 
            : this(user, DateTime.Now)
        {

        }
    }
}
