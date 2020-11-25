using Socio.BusinessNew.Models;
using System.Collections.Generic;

namespace Socio.BusinessNew.Abstraction
{
    public interface IConversationService
    {
        ExtendedConversationModel GetConversation(int userToId, int userFromId);
        List<ConversationViewModel> GetConversations(int userId);
        List<UserProfileViewModel> GetUsers(List<NewConversation> convs);
    }
}
