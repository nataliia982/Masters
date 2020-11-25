using Socio.Business.Managers.Interfaces;
using Socio.Business.Managers.Base.Implementations;
using Socio.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Socio.Business.Models;
using Socio.Data.Repository.Base.Interfaces;
using AutoMapper;

namespace Socio.Business.Managers.Implementations
{
    public class FeedMessageManager : CrudManager<FeedMessage, FeedMessageModel>, IFeedMessageManager
    {
        public FeedMessageManager(
            IApplicationUnitOfWork unitOfWork) 
            : base(unitOfWork, unitOfWork.Feeds)
        {
        }

        public override  Task UpdateAsync(FeedMessageModel model)
        {
            model.WasEdited = true;
            return base.UpdateAsync(model);
        }

        public async Task<List<FeedMessageModel>> GetAllFeedForUser(int userProfileId)
        {
            return Mapper.Map<List<FeedMessageModel>>(
                await UnitOfWork.Feeds.GetFeedsForUser(userProfileId));
        }
    }
}
