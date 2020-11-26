using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Socio.Business.Models.Base;

namespace Socio.Business.Models
{
    public class MessageModel : IModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public int UserProfileId { get; set; }
        public UserProfileModel UserProfile { get; set; }

        public int ConversationId { get; set; }
        public ConversationModel Conversation { get; set; }

        public string Body { get; set; }
    }
}
