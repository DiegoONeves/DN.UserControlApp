using DN.UserControlApp.Domain.Account.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.UserControlApp.Domain.Account.Commands;
using DN.UserControlApp.Domain.Account.Entities;
using DN.UserControlApp.Domain.Account.Repositories;
using DN.UserControlApp.SharedKernel.Repositories.Contracts;
using DN.UserControlApp.SharedKernel.Events;
using DN.UserControlApp.Domain.Account.Events.UserEvents;

namespace DN.UserControlApp.Application.Account.Services.UserServices
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        private IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnityOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }
        public User Register(RegisterUserCommand command)
        {
            var user = new User(command.UserName, command.Password);
            user.Register();
            _repository.Register(user);

            if (Commit())
            {
                DomainEvent.Raise(new UserRegistered(user));
                return user;
            }

            return null;
        }
        public bool Authenticate(string username, string password)
        {
            var user = _repository.Authenticate(username, password);
            return user != null;
        }


    }
}
