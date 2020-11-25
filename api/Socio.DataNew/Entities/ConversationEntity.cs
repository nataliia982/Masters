using Socio.DataNew.Entities.Abstraction;
using System.Collections.Generic;

namespace Socio.DataNew.Entities
{
    public class ConversationEntity : BaseEntity
    {
        public List<MessageEntity> Messages { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
