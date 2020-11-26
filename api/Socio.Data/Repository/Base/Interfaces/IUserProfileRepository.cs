using Socio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Data.Repository.Base.Interfaces
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        Task<UserProfile> GetByLoginAsync(string login);
        Task<UserProfile> GetByEmailAsync(string email);
    }
}
