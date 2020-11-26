using Socio.BusinessNew.Models;

namespace Socio.BusinessNew.Abstraction
{
    public interface IMessageService
    {
        MessageViewModel PostMessage(NewMessageViewModel model, int userId);
    }
}
