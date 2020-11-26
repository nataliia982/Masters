using System.Collections.Generic;
using Socio.BusinessNew.Abstraction;
using Socio.BusinessNew.Models;
using System.Data;
using Dapper;
using System.Linq;
using System;

namespace Socio.BusinessNew.StoredImplementations
{
    public class SFeedService : BaseService, IFeedService
    {
        public FeedMessageViewModel CreateFeed(FeedMessageViewModel model, int userId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var feed = dbConnection.Query<FeedMessageViewModel>("PostFeed", new { UserFromId = userId, UserToId = model.UserId, WasEdited = false, IsDeleted = false, FeedText = model.FeedText },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                return feed;
            }
        }

        public void DeleteFeed(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Execute("DeleteFeed", new { FeedId = id }, commandType: CommandType.StoredProcedure);
                return;
            }
        }

        public List<FeedMessageViewModel> GetFeeds(int userId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var feeds = dbConnection.Query<FeedMessageViewModel>("GetFeeds", new { UserId = userId },
                    commandType: CommandType.StoredProcedure).ToList();
                return feeds;
            }
        }

        public FeedMessageViewModel UpdateFeed(FeedMessageViewModel model)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Execute("UpdateFeed", new { FeedId = model.Id, FeedText = model.FeedText }, commandType: CommandType.StoredProcedure);
            }

            model.WasEdited = true;
            return model;
        }
    }
}
