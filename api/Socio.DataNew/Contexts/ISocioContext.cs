using System.Data.Entity;

namespace Socio.DataNew.Contexts
{
    public interface ISocioContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }

}
