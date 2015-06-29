namespace ManagementSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using ManagementSystem.Common;
    using ManagementSystem.Data;
    using ManagementSystem.Web.ViewModels;

    using PagedList;

    public class HomeController : BaseController
    {
        public HomeController(IManagementSystemData data)
            : base(data)
        {
        }

        public ActionResult Index(int? page)
        {
            var tasks = this.Data.Tasks
                .All()
                .OrderBy(x => x.Id)
                .Project()
                .To<TaskViewModel>()
                .ToPagedList(page ?? GlobalConstants.DefaultStartPage, GlobalConstants.DefaultPageSize);

            return this.View(tasks);
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}