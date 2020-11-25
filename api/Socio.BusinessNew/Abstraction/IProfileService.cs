using Socio.BusinessNew.Models;
using System.Collections.Generic;

namespace Socio.BusinessNew.Abstraction
{
    public interface IProfileService
    {
        UserAccountModel IsBanned(string login);
        UserProfileViewModel GetByLogin(string login);
        void UpdateUser(UserProfileViewModel model);
        void EditPassword(string newPassword, int id);
        List<UserProfileViewModel> GetAllUsers();
        void BanUser(int userId);
    }
}
