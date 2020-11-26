using Socio.DataNew.Contexts;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Socio.DataNew
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SocioContext context;

        private IDbSet<T> entities;

        public Repository(SocioContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }

        public T GetById(object id)
        {
            return this.entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                CheckForNull(entity);
                this.entities.Add(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                HandleValidationError(dbEx);
            }
        }

        public void Update(T entity)
        {
            try
            {
                CheckForNull(entity);
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                HandleValidationError(dbEx);
            }
        }

        public void RemoveRange(IQueryable<T> entities)
        {
            try
            {
                foreach (var entity in entities.ToList())
                {
                    this.context.Entry(entity).State = EntityState.Deleted;
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                HandleValidationError(dbEx);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                CheckForNull(entity);

                this.entities.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                HandleValidationError(dbEx);
            }
        }

        public void DeleteById(object id)
        {
            try
            {
                T entityToDelete = this.entities.Find(id);

                CheckForNull(entityToDelete);

                this.entities.Remove(entityToDelete);
            }
            catch (DbEntityValidationException dbEx)
            {
                HandleValidationError(dbEx);
            }
        }

        public IQueryable<T> Set => this.entities;

        public IQueryable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = this.entities;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = this.entities;
            return include.Aggregate(query, (current, inc) => current.Include(inc));
        }

        private static void HandleValidationError(DbEntityValidationException dbEx)
        {
            var errorMessage = new StringBuilder();

            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    errorMessage.Append($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}\n");
                }
            }
            throw new Exception(errorMessage.ToString(), dbEx);
        }

        private static void CheckForNull(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
        }
    }

}
