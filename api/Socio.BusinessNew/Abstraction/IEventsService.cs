using Socio.BusinessNew.Models;
using System.Collections.Generic;

namespace Socio.BusinessNew.Abstraction
{
    public interface IEventsService
    {
        List<EventViewModel> GetEvents();
    }
}
