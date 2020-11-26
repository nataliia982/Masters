using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Socio.Business.Models.Base;
using Socio.Data.Entities;

namespace Socio.Business.Models
{
    public class UserProfileModel : IModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public RoleEnum Role { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Position { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public string WebsiteLink { get; set; }

        public string FacebookLink { get; set; }

        public string TwitterLink { get; set; }

        public string City { get; set; }

        public string ProfileImageUrl { get; set; }

        public UserAccountModel UserAccount { get; set; }

        public int UserAccountId { get; set; }

    }
}
