using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Data.Repository.Base.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<IQueryable<Message>> GetByConversation(int id, int offset = 0, int count = 100);
    }
}
