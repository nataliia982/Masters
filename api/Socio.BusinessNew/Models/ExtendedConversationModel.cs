using System;
using System.Collections.Generic;

namespace Socio.BusinessNew.Models
{
    public class ExtendedConversationModel
    {
        public List<MessageViewModel> Messages { get; set; }
        public int ConversationId { get; set; }
    }
}
