using Socio.Business.Managers.Interfaces;
using Socio.Business.Models;
using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Socio.Data.Repository.Base.Interfaces;
using AutoMapper;
using Socio.Business.Managers.Base.Implementations;

namespace Socio.Business.Managers.Implementations
{
    public class ConversationManager : CrudManager<Conversation, ConversationModel>, IConversationManager
    {

        #region Properties



        #endregion

        #region Constructors

        public ConversationManager(IApplicationUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.Conversations)
        { }

        #endregion

        #region Interface Members

        public async Task<ConversationModel> GetByUsersIdsAsync(int userId, int userId2)
        {
                
            var conversationExists = await UnitOfWork.Conversations.GetByUsersIdsAsync(userId, userId2);
            if (conversationExists != null)
            {
                return Mapper.Map<ConversationModel>(conversationExists);
            }
            else
            {
                var user = await UnitOfWork.UserProfiles.GetAsync(userId);
                var user2 = await UnitOfWork.UserProfiles.GetAsync(userId2);
                
                if (user != null && user2 != null)
                {
                    var conversation = new ConversationModel();
                    conversation.UserProfiles = new List<UserProfileModel>();
                    conversation.DateCreated = DateTime.Now;
                    var model = Mapper.Map<Conversation>(conversation);

                    user.Conversations.Add(model);
                    user2.Conversations.Add(model);

                    await UnitOfWork.UserProfiles.UpdateAsync(user);
                    await UnitOfWork.UserProfiles.UpdateAsync(user2);

                    await UnitOfWork.SaveChanges();
                    return Mapper.Map<ConversationModel>(
                        await UnitOfWork.Conversations.GetByUsersIdsAsync(userId, userId2));
                }
                else
                {
                    return default(ConversationModel);
                }
            }
            
            
        }

        public async Task<List<ConversationModel>> GetByUserIdAsync(int userId)
        {
            var model = Mapper.Map<List<ConversationModel>>(
                await UnitOfWork.Conversations.GetByUserIdAsync(userId));
            model.ForEach(x =>
            {
                x.UserProfiles.RemoveAll(u => u.Id == userId);
                x.Messages.RemoveAll(m => m.DateCreated != x.Messages.Max(y => y.DateCreated));
            });

            return model;
        }

        #endregion

    }
}
