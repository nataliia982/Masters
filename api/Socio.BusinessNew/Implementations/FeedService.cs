using System;
using System.Collections.Generic;
using Socio.BusinessNew.Abstraction;
using Socio.BusinessNew.Models;
using Socio.DataNew;
using Socio.DataNew.Entities;
using System.Linq;

namespace Socio.BusinessNew.Implementations
{
    public class FeedService : IFeedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IRepository<FeedMessageEntity> _feedRepository;

        public FeedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.Repository<UserEntity>();
            _feedRepository = _unitOfWork.Repository<FeedMessageEntity>();
        }

        public FeedMessageViewModel CreateFeed(FeedMessageViewModel model, int userId)
        {
            var userTo = _userRepository.Include(x => x.ReceivedFeeds).FirstOrDefault(x => x.Id == model.UserId);
            var userFrom = _userRepository.Include(x => x.SentFeeds).FirstOrDefault(x => x.Id == userId);

            var feedToInsert = new FeedMessageEntity
            {
                DateCreated = DateTime.Now,
                WasEdited = model.WasEdited,
                FeedText = model.FeedText,
                IsDeleted = false,
                FromUser = userFrom,
                ToUser = userTo
            };
            _feedRepository.Insert(feedToInsert);
            _unitOfWork.SaveChanges();

            return new FeedMessageViewModel
            {
                Id = feedToInsert.Id,
                DateCreated = feedToInsert.DateCreated,
                Login = userFrom.Login,
                FeedText = feedToInsert.FeedText,
                Name = userFrom.Name,
                ProfileImageUrl = userFrom.ProfileImageUrl,
                Surname = userFrom.Surname,
                UserId = userFrom.Id,
                WasEdited = feedToInsert.WasEdited
            };
        }

        public void DeleteFeed(int id)
        {
            var deletedFeed = _feedRepository.Set.FirstOrDefault(x => x.Id == id);
            _feedRepository.Delete(deletedFeed);
            _unitOfWork.SaveChanges();
        }

        public List<FeedMessageViewModel> GetFeeds(int userId)
        {
            var feeds = _feedRepository.Include(x => x.FromUser, x => x.ToUser).Where(x => x.ToUser.Id == userId).Select(x => new FeedMessageViewModel
            {
                Id = x.Id,
                DateCreated = x.DateCreated,
                Login = x.FromUser.Login,
                FeedText = x.FeedText,
                WasEdited = x.WasEdited,
                Name = x.FromUser.Name,
                Surname = x.FromUser.Surname,
                ProfileImageUrl = x.FromUser.ProfileImageUrl,
                UserId = x.FromUser.Id                
            }).ToList();

            return feeds;
        }

        public FeedMessageViewModel UpdateFeed(FeedMessageViewModel model)
        {
            var editedFeed = _feedRepository.Set.FirstOrDefault(x => x.Id == model.Id);
            editedFeed.FeedText = model.FeedText;
            editedFeed.WasEdited = true;
            model.WasEdited = true;
            _unitOfWork.SaveChanges();

            return model;
        }
    }
}
