using Socio.BusinessNew.Abstraction;
using System;
using Socio.BusinessNew.Models;
using Socio.DataNew;
using Socio.DataNew.Entities;
using System.Linq;
using Socio.BusinessNew.Exceptions;

namespace Socio.BusinessNew.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserEntity> _userRepository;


        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.Repository<UserEntity>();
        }

        public UserLoginViewModel LogIn(string login, string password)
        {
            var user = _userRepository.Set.FirstOrDefault(x => x.Login == login && x.Password == password);

            return user == null ? null : new UserLoginViewModel
            {
                Id = user.Id,
                Role = user.Role
            };
        }

        public UserAccountModel SignUp(UserRegisterViewModel model)
        {
            if (_userRepository.Set.Any(x => x.Login == model.Login))
            {
                throw new LoginAlreadyExists();
            }

            if (_userRepository.Set.Any(x => x.Email == model.Email))
            {
                throw new EmailAlreadyExists();
            }

            var userToInsert = new UserEntity
            {
                Name = model.Name,
                Surname = model.Surname,
                Phone = model.Phone,
                City = model.City,
                Email = model.Email,
                Login = model.Login,
                Password = model.Password,
                Role = "User",
                IsBanned = false,
                IsDeleted = false,
                DateCreated = DateTime.Now,
                BirthDate = DateTime.Now
            };

            _userRepository.Insert(userToInsert);
            _unitOfWork.SaveChanges();

            return new UserAccountModel
            {
                Id = userToInsert.Id,
                DateCreated = userToInsert.DateCreated,
                Email = userToInsert.Email,
                IsBanned = userToInsert.IsBanned,
                Login = userToInsert.Login,
                Password = userToInsert.Password
            };
        }
    }
}
