using System;

namespace Socio.BusinessNew.Models
{
    public class MessageViewModel
    {
        public string Login { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateCreated { get; set; }
        public string Body { get; set; }
    }
}