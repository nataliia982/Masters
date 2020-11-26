using System;

namespace Socio.BusinessNew.Models
{
    public class FeedMessageViewModel
    {
        public int Id { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateCreated { get; set; }
        public bool WasEdited { get; set; }
        public int UserId { get; set; }
        public string FeedText { get; set; }
    }
}
