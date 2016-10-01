using DN.UserControlApp.Domain.Account.Entities;
using System;
using System.Linq.Expressions;

namespace DN.UserControlApp.Domain.Account.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> AuthenticateUser(string userName, string password)
        {
            return x => x.Email == userName && x.Password == password;
        }

        public static Expression<Func<User, bool>> IsActive()
        {
            return x => x.IsActive;
        }
    }
}
