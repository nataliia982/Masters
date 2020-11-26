using Socio.Data.Entities;
using Socio.Data.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Data.Repository.Base.Implementation
{
    public class FeedMessageRepository : Repository<FeedMessage>, IFeedMessageRepository
    {
        public FeedMessageRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FeedMessage>> GetFeedsForUser(int userProfileId)
        {
            return (await GetAsync())
                          .Where(x => x.ToUserProfileId == userProfileId)
                          .OrderByDescending(x => x.DateCreated);
        }
    }
}
