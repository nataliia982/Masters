using CMS.Data.Repository.Base.Interfaces;
using Socio.Data.Repository.Base.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Data.Repository.Base.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {

        #region Properties

        protected DbSet<TEntity> DbSet { get; set; }
        protected DataContext Context { get; set; }

        #endregion

        #region Constructors

        public Repository(DataContext context)
        {
            if (context == null)
            {
                throw new Exception("Context can`t be null");
            }

            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        #endregion

        #region Interface Members

        public virtual async Task<IQueryable<TEntity>> GetAsync()
        {
            return await Task.FromResult(DbSet.Select(x => x));
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await DbSet
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            await Task.FromResult(DbSet.Add(entity));
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var model = await DbSet.FindAsync(entity.Id);
            if(model!=null)
            {
                Context.Entry(model).CurrentValues.SetValues(entity);
            }
        }

        public virtual async Task DeleteAsync(int id)
        {
            var model = await DbSet.FirstAsync(x => x.Id == id);
            DbSet
                .Remove(model);
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

        #endregion

    }
}
