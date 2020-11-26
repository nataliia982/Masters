using Socio.BusinessNew.Abstraction;
using System;
using System.Collections.Generic;
using Socio.BusinessNew.Models;
using System.Data;
using Dapper;
using System.Linq;

namespace Socio.BusinessNew.StoredImplementations
{
    public class SEventsService : BaseService,IEventsService
    {

        public List<EventViewModel> GetEvents()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var conversations = dbConnection.Query<EventViewModel>("GetEvents",
                   commandType: CommandType.StoredProcedure).ToList();
                return conversations;
            }
        }
    }
}
