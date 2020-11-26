using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Data.Repository.Base.Interfaces
{
    public interface IApplicationUnitOfWork : IDisposable
    {
        IUserAccountRepository UserAccounts { get; }
        IUserProfileRepository UserProfiles { get; }
        IMessageRepository Messages { get; }
        IConversationRepository Conversations { get; }
        IFeedMessageRepository Feeds { get; }
        Task SaveChanges();
    }
}
