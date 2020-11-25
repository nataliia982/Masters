using System;

namespace Socio.BusinessNew.Exceptions
{
    public class EmailAlreadyExists : Exception
    {
        public EmailAlreadyExists()
            : base("Email already exists")
        { }
    }
}
