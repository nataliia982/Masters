using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Business.Managers.Interfaces
{
    public interface IManagerStore
    {
        IUserAccountManager UserAccountManager { get; }
        IUserProfileManager UserProfileManager { get; }
        IConversationManager ConversationManager { get; }
        IMessageManager MessageManager { get; }
        IAccountManager AccountManager { get; }
        IFeedMessageManager FeedMessageManager { get; }
    }
}
