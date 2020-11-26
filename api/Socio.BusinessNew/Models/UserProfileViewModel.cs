using System;

namespace Socio.BusinessNew.Models
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Position { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public string WebsiteLink { get; set; }

        public string FacebookLink { get; set; }

        public string TwitterLink { get; set; }

        public string City { get; set; }

        public string ProfileImageUrl { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool IsBanned { get; set; }
    }
}
