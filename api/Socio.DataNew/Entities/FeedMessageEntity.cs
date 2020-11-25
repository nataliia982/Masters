using Socio.DataNew.Entities.Abstraction;

namespace Socio.DataNew.Entities
{
    public class FeedMessageEntity : BaseEntity
    {
        public string FeedText { get; set; }
        public bool WasEdited { get; set; }
        public virtual UserEntity ToUser { get; set; }
        public virtual UserEntity FromUser { get; set; }
    }
}
