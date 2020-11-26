using Socio.BusinessNew.Abstraction;
using System;
using System.Collections.Generic;
using Socio.BusinessNew.Models;
using System.Data;
using Dapper;
using System.Linq;

namespace Socio.BusinessNew.StoredImplementations
{
    public class SConversationService : BaseService, IConversationService
    {
        public ExtendedConversationModel GetConversation(int userToId, int userFromId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var conId = dbConnection.Query<int?>("GetConversation", new { UserToId = userToId, UserFromId = userFromId },
                   commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (conId != null)
                {
                    var messages = dbConnection.Query<MessageViewModel>("GetConMessages", new { ConversationId = conId },
                        commandType: CommandType.StoredProcedure).ToList();

                    return new ExtendedConversationModel
                    {
                        Messages = messages,
                        ConversationId = conId.Value
                    };
                }
                else
                {
                    var creatId = dbConnection.Query<int>("CreatingConversation", new { IsDeleted = false, UserFromId = userFromId, UserToId = userToId },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return new ExtendedConversationModel
                    {
                        Messages = new List<MessageViewModel>(),
                        ConversationId = creatId
                    };
                }
            }
        }

        public List<ConversationViewModel> GetConversations(int userId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var conversations = dbConnection.Query<ConversationViewModel>("GetConversations", new { UserId = userId },
                   commandType: CommandType.StoredProcedure).ToList();
                return conversations;
            }
        }

        public List<UserProfileViewModel> GetUsers(List<NewConversation> convs)
        {
            throw new NotImplementedException();
        }
    }
}
