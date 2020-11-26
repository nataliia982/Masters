using Socio.Data.Entities;
using Socio.Data.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Data.Repository.Base.Implementation
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {

        #region Properties



        #endregion

        #region Constructors

        public MessageRepository(DataContext context)
                    : base(context)
        { }

        #endregion

        #region Interface Members

        public async Task<IQueryable<Message>> GetByConversation(int id, int offset = 0, int count = 100)
        {
            return await Task.FromResult(
                DbSet
                .Where(x => x.ConversationId == id)
                .Skip(offset)
                .Take(count < 0 || count> 200 ? 100 : count));
        }

        #endregion

    }
}
