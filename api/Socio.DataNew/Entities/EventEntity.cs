using Socio.DataNew.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.DataNew.Entities
{
    public class EventEntity : BaseEntity
    {
        public string Name { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string CriteriaList { get; set; }
        public UserEntity UserEntity { get; set; }
        public List<SubscribpitonEntity> Subscribrions { get; set; }
        public List<CommentEntity> Comments { get; set; }
    }
}
