using Socio.BusinessNew.Abstraction;
using System;
using System.Collections.Generic;
using Socio.BusinessNew.Models;
using System.Data;
using Dapper;
using System.Linq;

namespace Socio.BusinessNew.StoredImplementations
{
    public class SProfileService : BaseService, IProfileService
    {
        public void BanUser(int userId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Execute("BanUser", new { UserId = userId }, commandType: CommandType.StoredProcedure);
                return;
            }
        }

        public void EditPassword(string newPassword, int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Execute("EditPassword", new { UserId = id, Password = newPassword }, commandType: CommandType.StoredProcedure);
                return;
            }
        }

        public List<UserProfileViewModel> GetAllUsers()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var users = dbConnection.Query<UserProfileViewModel>("GetAllUsers", commandType: CommandType.StoredProcedure).ToList();
                return users;
            }
        }

        public UserProfileViewModel GetByLogin(string login)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var user = dbConnection.Query<UserProfileViewModel>("GetByLogin", new { Login = login },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                return user;
            }
        }

        public UserAccountModel IsBanned(string login)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var user = dbConnection.Query<UserAccountModel>("IsBanned", new { Login = login },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                return user;
            }
        }

        public void UpdateUser(UserProfileViewModel model)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Execute("UpdateUser", new { UserId = model.Id,  Name = model.Name, Surname = model.Surname, Phone = model.Phone, Position = model.Position, City = model.City, WebsiteLink = model.WebsiteLink, FacebookLink = model.FacebookLink, TwitterLink = model.TwitterLink }, 
                    commandType: CommandType.StoredProcedure);
                return;
            }
        }
    }
}
