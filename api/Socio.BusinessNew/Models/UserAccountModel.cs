using System;

namespace Socio.BusinessNew.Models
{
    public class UserAccountModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsBanned { get; set; }
    }
}
