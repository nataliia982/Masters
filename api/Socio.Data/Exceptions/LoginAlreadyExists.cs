using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Data.Exceptions
{
    public class LoginAlreadyExists : Exception
    {
        public LoginAlreadyExists():
            base("Login already exists")
        { }
    }
}
