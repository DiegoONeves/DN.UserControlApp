using DN.UserControlApp.Domain.Account.Repositories;
using System;
using System.Linq;
using DN.UserControlApp.Domain.Account.Entities;
using DN.UserControlApp.Infra.Data.ORM.Contexts;
using DN.UserControlApp.SharedKernel.Events;
using DN.UserControlApp.Domain.Account.Specs;

namespace DN.UserControlApp.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserControlDataContext _context;
        public UserRepository(UserControlDataContext context)
        {
            _context = context;
        }
        public void Register(User user)
        {
            try
            {
                _context.Users.Add(user);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("IX_USER_EMAIL"))
                    DomainEvent.Raise(new DomainNotification("User", "Este E-mail já está sendo utilizado."));
                else
                    DomainEvent.Raise(new DomainNotification("User", "Falha ao cadastrar usuário"));
            }

        }

        public User Authenticate(string userName, string password)
        {
            return _context.Users
                .Where(UserSpecs.AuthenticateUser(userName, password))
                .FirstOrDefault();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
