using CMS.Data.Repository.Base.Interfaces;
using Socio.Business.Models.Base;
using Socio.Data.Repository.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socio.Business.Managers.Base.Interfaces
{
    public interface ICrudManager<TModel> 
        where TModel: class, IModel
    {
        Task<int> AddAsync(TModel model);
        Task<List<TModel>> GetAsync();
        Task<TModel> GetAsync(int id);
        Task UpdateAsync(TModel model);
        Task DeleteAsync(int id);

    }
}
