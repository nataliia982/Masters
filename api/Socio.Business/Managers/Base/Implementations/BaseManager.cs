using Socio.Data.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Socio.Business.Managers.Base.Implementations
{
    public abstract class BaseManager<TEntity> : IDisposable
        where TEntity : class
    {

        #region Fields

        private readonly IApplicationUnitOfWork unitOfWork;
        private readonly IRepository<TEntity> repository;

        #endregion

        #region Properties

        protected IApplicationUnitOfWork UnitOfWork
        {
            get { return unitOfWork; }
        }

        protected IRepository<TEntity> Repository
        {
            get { return repository; }
        }

        #endregion

        #region Constructors

        protected BaseManager(IApplicationUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        #endregion


        public void Dispose()
        {
            if(unitOfWork != null)
            {
                unitOfWork.Dispose();
            }
        }
    }
}
