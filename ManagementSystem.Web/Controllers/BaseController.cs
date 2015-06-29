namespace ManagementSystem.Web.Controllers
{
    using System.Web.Mvc;

    using ManagementSystem.Data;

    public abstract class BaseController : Controller
    {
        protected BaseController(IManagementSystemData data)
        {
            this.Data = data;
        }

        public IManagementSystemData Data { get; private set; }
    }
}