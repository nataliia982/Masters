using Socio.Data.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Data.Repository.Base.Implementation
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        private DataContext _context;
        private IUserAccountRepository _userAccounts;
        private IUserProfileRepository _userProfiles;
        private IMessageRepository _messages;
        private IConversationRepository _conversations;
        private IFeedMessageRepository _feeds;
        
        public IUserAccountRepository UserAccounts { get { return _userAccounts ?? (_userAccounts = new UserAccountRepository(_context)); } }
        public IUserProfileRepository UserProfiles { get { return _userProfiles ?? (_userProfiles = new UserProfileRepository(_context)); } }
        public IMessageRepository Messages { get { return _messages ?? (_messages = new MessageRepository(_context)); } }
        public IConversationRepository Conversations { get { return _conversations ?? (_conversations = new ConversationRepository(_context)); } }
        public IFeedMessageRepository Feeds { get { return _feeds ?? (_feeds = new FeedMessageRepository(_context)); } }

        //private DataContext dataContext;

        public ApplicationUnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if(_context!=null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
