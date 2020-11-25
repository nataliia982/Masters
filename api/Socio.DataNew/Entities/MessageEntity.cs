using Socio.DataNew.Entities.Abstraction;
namespace Socio.DataNew.Entities
{
    public class MessageEntity : BaseEntity
    {
        public ConversationEntity Conversation { get; set; }
        public string Body { get; set; }
        public UserEntity User { get; set; }
    }
}
