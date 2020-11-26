using Socio.Data.Entities.Base;

namespace Socio.Data.Entities
{
    public class Message : Entity
    {
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }

        public string Body { get; set; }

    }
}
