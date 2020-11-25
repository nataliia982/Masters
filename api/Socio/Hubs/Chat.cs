using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Socio.App_Start;
using Socio.Business.Managers.Implementations;
using Socio.Business.Managers.Interfaces;
using Socio.Business.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Ninject;

namespace Socio.Hubs
{
    [HubName("chat")]
    public class Chat : Hub
    {
        private readonly static ConnectionMapping<int> _connections = new ConnectionMapping<int>();
        private IManagerStore manager = NinjectWebCommon.Kernel.Get<IManagerStore>();

        public void Send(string message, int conversationId)
        {
            int senderUserId = int.Parse(Context.QueryString["userId"]);
            var messageModel = new MessageModel()
            {
                Body = message,
                UserProfileId = senderUserId,
                ConversationId = conversationId
            };
            int messgeId = manager.MessageManager.AddAsync(messageModel).Result;
            var dbMessage = manager.MessageManager.GetAsync(messgeId).Result;
            
            foreach (var user in dbMessage.Conversation.UserProfiles)
            {
                Clients.Client(_connections.GetConnections(user.Id).FirstOrDefault()).send(dbMessage);
            }
            Clients.All.send(message);
        }

        public override Task OnConnected()
        {
            int userId = int.Parse(Context.QueryString["userId"]);

            _connections.Add(userId, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            int userId = int.Parse(Context.QueryString["userId"]);

            _connections.Remove(userId, Context.ConnectionId);

            return base.OnDisconnected(true);
        }
    }
}