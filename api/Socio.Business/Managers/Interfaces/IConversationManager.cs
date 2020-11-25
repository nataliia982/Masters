using Socio.Business.Managers.Base.Interfaces;
using Socio.Business.Models;
using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Business.Managers.Interfaces
{
    public interface IConversationManager : ICrudManager<ConversationModel>
    {
        Task<ConversationModel> GetByUsersIdsAsync(int userId, int userId2);
        Task<List<ConversationModel>> GetByUserIdAsync(int userId);
    }
}
