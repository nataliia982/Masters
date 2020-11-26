using Socio.Data.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Repository.Base.Interfaces
{
    public interface IEntity : IBaseEntity
    {
        bool IsDeleted { get; set; }
        DateTime DateCreated { get; set; }
    }
}
