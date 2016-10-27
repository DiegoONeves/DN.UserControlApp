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
                    AssertionConcern.AssertArgumentLength(user.FirstName, 3, 10, "O primeiro nome deve ter entre 3 e 10 caracteres."),
                    AssertionConcern.AssertNotEmpty(user.Email, "O usuário não foi informado."),
                    AssertionConcern.AssertArgumentLength(user.Email, 80, "O e-mail deve ter no máximo 80 caracteres."),
                    AssertionConcern.AssertNotEmpty(user.Password, "A senha do usuário não foi informada.")
                );
        }
    }
}
