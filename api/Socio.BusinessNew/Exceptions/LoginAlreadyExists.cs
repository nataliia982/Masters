using System;

namespace Socio.BusinessNew.Exceptions
{
    public class LoginAlreadyExists : Exception
    {
        public LoginAlreadyExists() :
            base("Login already exists")
        { }
    }
}
