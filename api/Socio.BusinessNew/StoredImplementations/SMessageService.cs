using Socio.BusinessNew.Abstraction;
using System;
using Socio.BusinessNew.Models;
using System.Data;
using Dapper;
using System.Linq;

namespace Socio.BusinessNew.StoredImplementations
{
    public class SMessageService : BaseService, IMessageService
    {
        public MessageViewModel PostMessage(NewMessageViewModel model, int userId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var message = dbConnection.Query<MessageViewModel>("PostMessage", new { UserId = userId, ConversationId = model.ConversationId, Body = model.Body, IsDeleted = false },
                   commandType: CommandType.StoredProcedure).FirstOrDefault();

                return message;

            }
        }
    }
}
