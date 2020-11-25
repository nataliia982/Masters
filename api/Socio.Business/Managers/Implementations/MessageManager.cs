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
    public class MessageManager : CrudManager<Message, MessageModel>, IMessageManager
    {

        #region Properties



        #endregion

        #region Constructors

        public MessageManager(IApplicationUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.Messages)
        { }

        #endregion

        #region Interface Members

        public async Task<List<MessageModel>> GetByConversation(int id, int offset = 0, int count = 0)
        {
            return Mapper.Map<List<MessageModel>>(
                await UnitOfWork.Messages.GetByConversation(id, offset, count));
        }

        #endregion

    }
}
