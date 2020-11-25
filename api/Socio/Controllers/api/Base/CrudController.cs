using System.Threading.Tasks;
using Socio.Business.Managers.Base.Interfaces;
using Socio.Business.Models.Base;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Socio.Business.Managers.Interfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Socio.Controllers.Base
{
    public abstract class CrudController<TModel> : BaseController<TModel>
        where TModel : class, IModel
    {
        

        #region Constructors

        public CrudController(IManagerStore managerStore, ICrudManager<TModel> manager)
            :base(managerStore, manager)
        { }

        #endregion

        #region Actions

        [HttpGet]
        [Route("")]
        public virtual async Task<HttpResponseMessage> GetAsync()
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                await base.Manager.GetAsync());
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        public virtual async Task<HttpResponseMessage> GetAsync(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                await base.Manager.GetAsync(id));
        }

        [HttpPost]
        [Route("")]
        public virtual async Task<HttpResponseMessage> CreateAsync([FromBody]TModel model)
        {
            int id = await Manager.AddAsync(model);
            model.Id = id;
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpPut]
        [Route("")]
        public virtual async Task<HttpResponseMessage> UpdateAsync(TModel model)
        {
            await Manager.UpdateAsync(model);

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        public virtual async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            await Manager.DeleteAsync(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion
    }
}
