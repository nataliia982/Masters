using Socio.BusinessNew.Abstraction;
using System.Collections.Generic;
using System.Linq;
using Socio.BusinessNew.Models;
using Socio.DataNew;
using Socio.DataNew.Entities;
using System;

namespace Socio.BusinessNew.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepository;
        
        public ProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.Repository<UserEntity>();
        }

        public void BanUser(int userId)
        {
            var user = _userRepository.Set.FirstOrDefault(x => x.Id == userId);
            user.IsBanned = user.IsBanned == true ? false : true;
            _unitOfWork.SaveChanges();
            return;
        }

        public void EditPassword(string newPassword, int id)
        {
            var editedUser = _userRepository.Set.FirstOrDefault(x => x.Id == id);

            editedUser.Password = newPassword;

            _unitOfWork.SaveChanges();
        }

        public List<UserProfileViewModel> GetAllUsers()
        {
            var res = _userRepository.Set.Select(x => new UserProfileViewModel
            {
                Id = x.Id,
                FacebookLink = x.FacebookLink,
                Login = x.Login,
                BirthDate = x.BirthDate,
                City = x.City,
                DateCreated = x.DateCreated,
                Email = x.Email,
                IsBanned = x.IsBanned,
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

            return res;
        }

        public UserProfileViewModel GetByLogin(string login)
        {
            var res = _userRepository.Set.Select(x => new UserProfileViewModel
            {
                Id = x.Id,
                FacebookLink = x.FacebookLink,
                Login = x.Login,
                BirthDate = x.BirthDate,
                City = x.City,
                DateCreated = x.DateCreated,
                Email = x.Email,
                IsBanned = x.IsBanned,
                Name = x.Name,
                Password = x.Password,
                Phone = x.Phone,
                Position = x.Position,
                ProfileImageUrl = x.ProfileImageUrl,
                Role = x.Role,
                Surname = x.Surname,
                TwitterLink = x.TwitterLink,
                WebsiteLink = x.WebsiteLink
            }).FirstOrDefault(x => x.Login == login);

            return res;
        }

        public UserAccountModel IsBanned(string login)
        {
            var res = _userRepository.Set.Select(x => new UserAccountModel { Id = x.Id, DateCreated = x.DateCreated, Email = x.Email, IsBanned = x.IsBanned, Login = x.Login, Password = x.Password }).FirstOrDefault(x => x.Login == login);
            return res;
        }

        public void UpdateUser(UserProfileViewModel model)
        {
            var updatedUser = _userRepository.Set.FirstOrDefault(x => x.Id == model.Id);

            updatedUser.Name = model.Name;
            updatedUser.Surname = model.Surname;
            updatedUser.Phone = model.Phone;
            updatedUser.Position = model.Position;
            updatedUser.City = model.City;
            updatedUser.WebsiteLink = model.WebsiteLink;
            updatedUser.FacebookLink = model.FacebookLink;
            updatedUser.TwitterLink = model.TwitterLink;

            _unitOfWork.SaveChanges();
        }
    }
}
