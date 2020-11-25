using Socio.DataNew.Entities.Abstraction;
using System;
using System.Collections.Generic;

namespace Socio.DataNew.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool IsBanned { get; set; }

        public string Role { get; set; }

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
        public List<ConversationEntity> Conversations { get; set; }
        public List<MessageEntity> Messages { get; set; }
        public List<FeedMessageEntity> ReceivedFeeds { get; set; }
        public List<FeedMessageEntity> SentFeeds { get; set; }
        public List<EventEntity> EventsCreated { get; set; }
        public List<SubscribpitonEntity> Subscribtions { get; set; }
        public List<CommentEntity> Comments { get; set; }
    }
}
