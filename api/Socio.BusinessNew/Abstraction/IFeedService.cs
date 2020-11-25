using Socio.BusinessNew.Models;
using System.Collections.Generic;

namespace Socio.BusinessNew.Abstraction
{
    public interface IFeedService
    {
        List<FeedMessageViewModel> GetFeeds(int userId);
        FeedMessageViewModel CreateFeed(FeedMessageViewModel model, int userId);
        FeedMessageViewModel UpdateFeed(FeedMessageViewModel model);
        void DeleteFeed(int id);
    }
}
