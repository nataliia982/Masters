using Socio.Business.Managers.Base.Interfaces;
using Socio.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Socio.Business.Managers.Interfaces
{
    public interface IFeedMessageManager : ICrudManager<FeedMessageModel>
    {
        Task<List<FeedMessageModel>> GetAllFeedForUser(int userProfileId);
    }
}
