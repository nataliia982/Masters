using Socio.DataNew.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.DataNew.Entities
{
    public class CommentEntity: BaseEntity
    {
        public string Text { get; set; }
        public UserEntity User { get; set; }
        public EventEntity Event { get; set; }
    }
}
