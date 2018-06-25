using System.Web.Mvc;

using Ninject;
using Tui.DataAccessInterfaces.UnitOfWork;

namespace Tui.Presentation.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
          
        }
    }
}
