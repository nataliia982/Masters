using System;
using Socio.Business.Models.Base;
using Socio.Data.Entities;

namespace Socio.Business.Models
{
    public class UserAccountModel : IModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsBanned { get; set; }
    }
}
