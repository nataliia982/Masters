using Socio.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Data.Entities
{
    public class FeedMessage : Entity
    {
        public string FeedText { get; set; }

        public bool WasEdited { get; set; }

        public int ToUserProfileId { get; set; }
        [ForeignKey("ToUserProfileId")]
        public virtual UserProfile ToUserProfile { get; set; }

        public int FromUserProfileId { get; set; }
        [ForeignKey("FromUserProfileId")]
        public virtual UserProfile FromUserProfile { get; set; }
    }
}
