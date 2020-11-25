using System.Data;
using System.Data.SqlClient;

namespace Socio.BusinessNew.StoredImplementations
{
    public abstract class BaseService
    {
        public IDbConnection Connection
        {
            get { return new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Socio;Integrated Security=True"); }
        }
    }
}
