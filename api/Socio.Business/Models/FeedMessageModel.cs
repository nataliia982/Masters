using Socio.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Business.Models
{
    public class FeedMessageModel : IModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        public string FeedText { get; set; }

        public bool WasEdited { get; set; }

        public UserProfileModel ToUserProfile { get; set; }
        public int ToUserProfileId { get; set; }

        public UserProfileModel FromUserProfile { get; set; }
        public int FromUserProfileId { get; set; }
    }
}
