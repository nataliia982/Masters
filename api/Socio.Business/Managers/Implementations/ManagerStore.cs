using Socio.Business.Managers.Interfaces;
using Socio.Data.Repository.Base.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Business.Managers.Implementations
{
    public class ManagerStore : IManagerStore
    {
        IUserAccountManager _userAccountManager;
        IUserProfileManager _userProfileManager;
        IConversationManager _conversationManager;
        IMessageManager _messageManager;
        IAccountManager _accountManager;
        IFeedMessageManager _feedMessageManager;
        IKernel kernel;

        public ManagerStore(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public IUserAccountManager UserAccountManager { get { return _userAccountManager ?? (_userAccountManager = kernel.Get<IUserAccountManager>()); } }
        
        public IUserProfileManager UserProfileManager { get { return _userProfileManager ?? (_userProfileManager = kernel.Get<IUserProfileManager>()); } }
        
        public IConversationManager ConversationManager { get { return _conversationManager ?? (_conversationManager = kernel.Get<IConversationManager>()); } }
        
        public IMessageManager MessageManager { get { return _messageManager ?? (_messageManager = kernel.Get<IMessageManager>()); } }
        
        public IAccountManager AccountManager { get { return _accountManager ?? (_accountManager = kernel.Get<IAccountManager>()); } }

        public IFeedMessageManager FeedMessageManager { get { return _feedMessageManager ?? (_feedMessageManager = kernel.Get<IFeedMessageManager>()); } }
    }
}
