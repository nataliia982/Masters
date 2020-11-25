using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using ExoftSocio.Business.Managers.Implementations;
using ExoftSocio.Business.Managers.Interfaces;
using ExoftSocio.Business.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Ninject;

namespace ExoftSocio.Hubs
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<int> _connections = new ConnectionMapping<int>();
        private IManagerStore manager;

        public ChatHub(IManagerStore managerStore)
        {
            manager = managerStore;
        }

        public async void Send(string message, int conversationId)
        {
            int senderUserId = int.Parse(Context.QueryString["userId"]);
            var messageModel = new MessageModel()
            {
                Body = message,
                UserProfileId = senderUserId,
                СonversationId = conversationId
            };
            int messgeId = await manager.MessageManager.AddAsync(messageModel);
            var dbMessage = await manager.MessageManager.GetAsync(messgeId);

            foreach (var user in dbMessage.Conversation.Users)
            {
                Clients.Client(_connections.GetConnections(user.Id).FirstOrDefault()).send(dbMessage);
            }
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