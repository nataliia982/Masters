using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Socio.Business.Models.Base;

namespace Socio.Business.Models
{
    public class ConversationModel : IModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public List<MessageModel> Messages { get; set; }

        public List<UserProfileModel> UserProfiles { get; set; }
    }
}
