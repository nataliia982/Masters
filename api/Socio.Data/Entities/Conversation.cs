using System.Collections.Generic;
using Socio.Data.Entities.Base;

namespace Socio.Data.Entities
{
    public class Conversation : Entity
    {
        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
