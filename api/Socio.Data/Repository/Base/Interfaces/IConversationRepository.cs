using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Data.Repository.Base.Interfaces
{
    public interface IConversationRepository : IRepository<Conversation>
    {
        Task<Conversation> GetByUsersIdsAsync(int userId, int userId2);
        Task<IQueryable<Conversation>> GetByUserIdAsync(int userId);
    }
}
