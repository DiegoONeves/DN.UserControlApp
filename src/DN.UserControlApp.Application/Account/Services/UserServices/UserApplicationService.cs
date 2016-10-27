using DN.UserControlApp.Domain.Account.Commands;
using DN.UserControlApp.Domain.Account.Entities;
using DN.UserControlApp.Domain.Account.Events.UserEvents;
using DN.UserControlApp.Domain.Account.Repositories;
using DN.UserControlApp.Domain.Account.Services;
using DN.UserControlApp.SharedKernel.Events;
using DN.UserControlApp.SharedKernel.Repositories.Contracts;
using System;

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

        public User Update(UpdateUserCommand command)
        {
            throw new NotImplementedException();
        }

        public void ResetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(ChangePasswordCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
