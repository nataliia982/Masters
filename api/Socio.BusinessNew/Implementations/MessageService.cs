using System;
using Socio.BusinessNew.Abstraction;
using Socio.BusinessNew.Models;
using Socio.DataNew;
using Socio.DataNew.Entities;
using System.Linq;

namespace Socio.BusinessNew.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<MessageEntity> _messageRepository;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<ConversationEntity> _conversationRepository;

        public MessageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _messageRepository = unitOfWork.Repository<MessageEntity>();
            _userRepository = unitOfWork.Repository<UserEntity>();
            _conversationRepository = unitOfWork.Repository<ConversationEntity>();
        }

        public MessageViewModel PostMessage(NewMessageViewModel model, int userId)
        {
            var user = _userRepository.Set.FirstOrDefault(x => x.Id == userId);
            var conversation = _conversationRepository.Set.FirstOrDefault(x => x.Id == model.ConversationId);

            var messageToInsert = new MessageEntity
            {
                Body = model.Body,
                IsDeleted = false,
                User = user,
                DateCreated = DateTime.Now,
                Conversation = conversation
            };
            _messageRepository.Insert(messageToInsert);

            _unitOfWork.SaveChanges();

            return new MessageViewModel
            {
                Body = messageToInsert.Body,
                DateCreated = messageToInsert.DateCreated,
                Login = user.Login,
                Name = user.Name,
                ProfileImageUrl = user.ProfileImageUrl,
                Surname = user.Surname
            };
        }
    }
}
