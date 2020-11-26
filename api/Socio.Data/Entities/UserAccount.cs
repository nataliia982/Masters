using Socio.Data.Entities.Base;

namespace Socio.Data.Entities
{
    public class UserAccount : Entity
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool IsBanned { get; set; }
    }
}
