using Socio.Business.Managers.Base.Interfaces;
using Socio.Business.Managers.Interfaces;
using Socio.Business.Models.Base;
using System.Web.Http;

namespace Socio.Controllers.Base
{
    public abstract class BaseController<TModel> : ApiController
        where TModel : class, IModel
    {
        #region Properties

        protected ICrudManager<TModel> Manager { get; set; }
        protected IManagerStore ManagerStore { get; set; }

        #endregion

        #region Constructors

        protected BaseController(IManagerStore managerStore, ICrudManager<TModel> manager)
        {
            Manager = manager;
            ManagerStore = managerStore;
        }

        #endregion
    }
}
