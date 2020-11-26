using System.Collections.Generic;
using Socio.BusinessNew.Abstraction;
using Socio.BusinessNew.Models;
using Socio.DataNew;
using Socio.DataNew.Entities;
using System.Linq;
using System;

namespace Socio.BusinessNew.Implementations
{
    public class ConversationService : IConversationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<MessageEntity> _messageRepository;
        private readonly IRepository<ConversationEntity> _conversationRepository;
        
        public ConversationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.Repository<UserEntity>();
            _messageRepository = unitOfWork.Repository<MessageEntity>();
            _conversationRepository = unitOfWork.Repository<ConversationEntity>();
        }
        
        public ExtendedConversationModel GetConversation(int userToId, int userFromId)
        {
            var conversation = _conversationRepository
                .Include(x => x.Users).FirstOrDefault(x => x.Users.Any(y => y.Id == userToId) && x.Users.Any(y => y.Id == userFromId));

            if (conversation == null)
            {
                var userTo = _userRepository.Set.FirstOrDefault(x => x.Id == userToId);
                var userFrom = _userRepository.Set.FirstOrDefault(x => x.Id == userFromId);

                var conversationToInsert = new ConversationEntity
                {
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    Messages = new List<MessageEntity>(),
                    Users = new List<UserEntity> { userTo, userFrom }
                };
                _conversationRepository.Insert(conversationToInsert);
                _unitOfWork.SaveChanges();

                return new ExtendedConversationModel
                {
                    Messages = new List<MessageViewModel>(),
                    ConversationId = conversationToInsert.Id
                };
            }
            else
            {
                var messages = _messageRepository.Include(x => x.User, x => x.Conversation).Where(x => x.Conversation.Id == conversation.Id)
                    .Select(x => new MessageViewModel
                    {
                        Body = x.Body,
                        DateCreated = x.DateCreated,
                        Login = x.User.Login,
                        Name = x.User.Name,
                        ProfileImageUrl = x.User.ProfileImageUrl,
                        Surname = x.User.Surname
                    }).OrderBy(x => x.DateCreated).ToList();

                return new ExtendedConversationModel
                {
                    Messages = messages,
                    ConversationId = conversation.Id
                };
            }
        }

        public List<ConversationViewModel> GetConversations(int userId)
        {
            var conversations = _conversationRepository.Include(x => x.Users, x => x.Messages.Select(y => y.User)).Where(x => x.Users.Any(y => y.Id == userId) && x.Messages.Count != 0);

            var res = conversations.Select(x => new ConversationViewModel
            {
                Id = x.Id,
                LastMessageBody = x.Messages.OrderByDescending(y => y.DateCreated).FirstOrDefault().Body,
                LastMessageDate = x.Messages.OrderByDescending(y => y.DateCreated).FirstOrDefault().DateCreated,
                UserImage = x.Messages.OrderByDescending(y => y.DateCreated).FirstOrDefault().User.ProfileImageUrl,
                UserLogin = x.Messages.OrderByDescending(y => y.DateCreated).FirstOrDefault().User.Login,
                UserName = x.Messages.OrderByDescending(y => y.DateCreated).FirstOrDefault().User.Name,
                UserSurname = x.Messages.OrderByDescending(y => y.DateCreated).FirstOrDefault().User.Surname,
                UserId = x.Messages.OrderByDescending(y => y.DateCreated).FirstOrDefault().User.Id
            }).ToList();

            return res;
        }

        public List<UserProfileViewModel> GetUsers(List<NewConversation> convs)
        {
            var convIds = convs.Where(x => x.IsChoosen == true).Select(x => x.Id);
            var users = _conversationRepository.Include(x => x.Users).Where(x => convIds.Contains(x.Id)).SelectMany(x => x.Users)
                .Select(x => new UserProfileViewModel
                {
                    Id = x.Id,
                    BirthDate = x.BirthDate,
                    City = x.City,
                    DateCreated = x.DateCreated,
                    Email = x.Email,
                    FacebookLink = x.FacebookLink,
                    IsBanned = x.IsBanned,
                    Login = x.Login,
                    Name = x.Name,
                    Password = x.Password,
                    Phone = x.Phone,
                    Position = x.Position,
                    ProfileImageUrl = x.ProfileImageUrl,
                    Role = x.Role,
                    Surname = x.Surname,
                    TwitterLink = x.TwitterLink,
                    WebsiteLink = x.WebsiteLink
                }).ToList();

            return users;
        }
    }
}
