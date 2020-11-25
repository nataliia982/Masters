using System;

namespace Socio.BusinessNew.Models
{
    public class ConversationViewModel
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public string UserImage { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime LastMessageDate { get; set; }
        public string LastMessageBody { get; set; }
        public int UserId { get; set; }
    }

    public class NewConversation
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public string UserImage { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime LastMessageDate { get; set; }
        public string LastMessageBody { get; set; }
        public int UserId { get; set; }
        public bool IsChoosen { get; set; }
    }
}