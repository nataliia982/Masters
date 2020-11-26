using System;
using Socio.BusinessNew.Abstraction;
using Socio.BusinessNew.Models;
using System.Data;
using Dapper;
using System.Linq;
using Socio.BusinessNew.Exceptions;

namespace Socio.BusinessNew.StoredImplementations
{
    public class SAccountService : BaseService, IAccountService
    {
        public UserLoginViewModel LogIn(string login, string password)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var user = dbConnection.Query<UserLoginViewModel>("UserLogin", new { Login = login, Password = password },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                return user;
            }
        }

        public UserAccountModel SignUp(UserRegisterViewModel model)
        {
            using (IDbConnection dbConnection = Connection)
            {
                if (dbConnection.Query<object>("CheckLogin", new { Login = model.Login },
                    commandType: CommandType.StoredProcedure).Count() > 0)
                {
                    throw new LoginAlreadyExists();
                }

                if (dbConnection.Query<object>("CheckEmail", new { Email = model.Email },
                    commandType: CommandType.StoredProcedure).Count() > 0)
                {
                    throw new EmailAlreadyExists();
                }

                var user = dbConnection.Query<UserAccountModel>("UserSignUp", new { Name = model.Name, Surname = model.Surname, Phone = model.Phone, City = model.City, Email = model.Email, Login = model.Login, Password = model.Password, Role = "User", IsBanned = false, IsDeleted = false },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                return user;
            }
        }
    }
}
