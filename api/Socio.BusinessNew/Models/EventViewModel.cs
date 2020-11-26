using System;
using System.Collections.Generic;

namespace Socio.BusinessNew.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string CriteriaList { get; set; }
        public int UserEntity { get; set; }
        public List<SubscribtionViewModel> Subscribtions { get; set; }
        public List<CommentViewModel> Comments { get; set; }

    }
}