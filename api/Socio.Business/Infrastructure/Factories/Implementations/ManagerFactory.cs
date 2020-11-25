using ExoftSocio.Business.Infrastructure.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoftSocio.Business.Infrastructure.Factories.Implementations
{
    public class ManagerFactory : IManagerFactory
    {
        IKernel kernel;
        public T Create<T>(string managerName)
        {
            return Activator.CreateInstance<T>()
        }
    }
}
