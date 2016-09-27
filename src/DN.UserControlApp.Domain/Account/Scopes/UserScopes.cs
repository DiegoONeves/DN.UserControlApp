using DN.UserControlApp.Domain.Account.Entities;
using DN.UserControlApp.SharedKernel.Validation;

namespace DN.UserControlApp.Domain.Account.Scopes
{
    public static class UserScopes
    {
        public static bool RegisterUserIsValid(this User user)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(user.UserName, "O usuário não foi informado."),
                    AssertionConcern.AssertNotEmpty(user.Password, "A senha do usuário não foi informada.")
                );
        }
    }
}
