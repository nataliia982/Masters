using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Socio.Data.Entities.Base;

namespace Socio.Data.Entities
{
    public class UserProfile : Entity
    {
        public RoleEnum Role { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Position { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public string ProfileImageUrl { get; set; }

        public string WebsiteLink { get; set; }

        public string FacebookLink { get; set; }

        public string TwitterLink { get; set; }

        public string City { get; set; }

        public int UserAccountId { get; set; }
        public virtual UserAccount UserAccount { get; set; }

        public ICollection<Conversation> Conversations { get; set; }

        public ICollection<UserProfile> Friends { get; set; }

        public UserProfile()
        {
            Conversations = new List<Conversation>();
            Friends = new List<UserProfile>();
        }

    }
}
