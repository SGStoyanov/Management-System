namespace ManagementSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using ManagementSystem.Common;
    using ManagementSystem.Data;
    using ManagementSystem.Web.InputModels;
    using ManagementSystem.Web.ViewModels;

    using PagedList;

    [Authorize]
    public class TasksController : BaseController
    {
        public TasksController(IManagementSystemData data)
            : base(data)
        {
        }

        // GET: Tasks
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

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {


            this.ViewBag.AssignedToUsers = this.Data.Users
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.UserName
                });

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskInputModel model)
        {
            return null;
        }
    }
}