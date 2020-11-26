using Socio.Business.Managers.Base.Interfaces;
using Socio.Business.Models;
using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Business.Managers.Interfaces
{
    public interface IMessageManager : ICrudManager<MessageModel>
    {
        Task<List<MessageModel>> GetByConversation(int id, int offset, int count);
    }
}
