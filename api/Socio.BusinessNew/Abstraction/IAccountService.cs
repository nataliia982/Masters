using Socio.BusinessNew.Models;

namespace Socio.BusinessNew.Abstraction
{
    public interface IAccountService
    {
        UserLoginViewModel LogIn(string login, string password);
        UserAccountModel SignUp(UserRegisterViewModel model);
    }
}
