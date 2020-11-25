using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoftSocio.Business.Infrastructure.Factories.Interfaces
{
    public interface IManagerFactory
    {
        T Create<T>(string managerName);
    }
}
