using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Business.Models.Base
{
    public interface IModel
    {
        int Id { get; set; }

        DateTime DateCreated { get; set; }
    }
}
