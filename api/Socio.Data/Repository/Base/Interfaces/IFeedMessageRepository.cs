using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Data.Repository.Base.Interfaces
{
    public interface IFeedMessageRepository : IRepository<FeedMessage>
    {
        Task<IEnumerable<FeedMessage>> GetFeedsForUser(int userProfileId);
    }
}
