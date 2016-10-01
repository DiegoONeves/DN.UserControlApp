using System;
using System.Collections.Generic;
using DN.UserControlApp.Domain.Account.Commands;
using DN.UserControlApp.Domain.Account.Entities;
using DN.UserControlApp.Domain.Account.Events.UserEvents;
using DN.UserControlApp.Domain.Account.Repositories;
using DN.UserControlApp.Domain.Account.Services;
using DN.UserControlApp.SharedKernel.Events;
using DN.UserControlApp.SharedKernel.Repositories.Contracts;

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
            var user = new User(command.FirstName, command.Email, command.Password);
            user.Register();
            _repository.Register(user);

            if (Commit())
            {
                DomainEvent.Raise(new UserRegistered(user));
                return user;
            }

            return null;
        }

        public User GetByEmail(string email)
        {
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
