using Socio.Data.Entities;
using Socio.Data.Repository.Base.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Data.Repository.Base.Implementation
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {

        #region Properties



        #endregion

        #region Constructors

        public UserProfileRepository(DataContext context)
                    : base(context)
        { }

        #endregion

        #region Interface Members

        public async Task<UserProfile> GetByLoginAsync(string login)
        {
            return await DbSet
                .Where(x => x.UserAccount.Login.Equals(login))
                .FirstOrDefaultAsync();
        }

        public async Task<UserProfile> GetByEmailAsync(string email)
        {
            return await DbSet
                .Where(x => x.UserAccount.Email.Equals(email))
                .FirstOrDefaultAsync();
        }

        #endregion

    }
}
