using AutoMapper;
using CMS.Data.Repository.Base.Interfaces;
using Socio.Business.Managers.Base.Interfaces;
using Socio.Business.Managers.Interfaces;
using Socio.Business.Models.Base;
using Socio.Data.Repository;
using Socio.Data.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Business.Managers.Base.Implementations
{
    public class CrudManager<TEntity, TModel> : BaseManager<TEntity> ,ICrudManager<TModel>
        where TEntity : class, IEntity
        where TModel : class, IModel
    {
        
        public CrudManager(IApplicationUnitOfWork unitOfWork, IRepository<TEntity> repository)
            :base(unitOfWork, repository)
        { }

        public virtual async Task<int> AddAsync(TModel model)
        {
            var dataModel = Mapper.Map<TEntity>(model);
            await Repository.AddAsync(dataModel);
            await UnitOfWork.SaveChanges();
            return dataModel.Id;
        }

        public virtual async Task UpdateAsync(TModel model)
        {
            await Repository.UpdateAsync(Mapper.Map<TEntity>(model));
            await UnitOfWork.SaveChanges();
        }

        public virtual async Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);
            await UnitOfWork.SaveChanges();
        }

        public virtual async Task<TModel> GetAsync(int id)
        {
            return Mapper.Map<TModel>(await Repository.GetAsync(id));
        }

        public virtual async Task<List<TModel>> GetAsync()
        {
            return Mapper.Map<List<TModel>>(await Repository.GetAsync());
        }
    }
}
