using Socio.Data.Entities;
using Socio.Data.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Socio.Data.Repository.Base.Implementation
{
    public class ConversationRepository : Repository<Conversation>, IConversationRepository
    {

        #region Properties



        #endregion

        #region Constructors

        public ConversationRepository(DataContext context)
            : base(context)
        { }

        #endregion

        #region Interface Members

        public async Task<Conversation> GetByUsersIdsAsync(int userId, int userId2)
        {
            return await DbSet
                .Where(x => 
            x.UserProfiles.Select(p => p.Id).Contains(userId) && 
            x.UserProfiles.Select(p => p.Id).Contains(userId2))
            .FirstOrDefaultAsync();
        }

        public async Task<IQueryable<Conversation>> GetByUserIdAsync(int userId)
        {
            return await Task.FromResult(DbSet.Where(x => x.UserProfiles.Select(p => p.Id).Contains(userId)));
        }

        #endregion

    }
}
