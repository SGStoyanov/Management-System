namespace ManagementSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using ManagementSystem.Common;
    using ManagementSystem.Data;
    using ManagementSystem.Models;
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
            this.LoadUsers();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var task = Mapper.Map<Task>(model);
                this.Data.Tasks.Add(task);
                this.Data.SaveChanges();

                return this.RedirectToRoute("Default");
            }

            this.LoadUsers();
            return this.View(model);

        }

        private void LoadUsers()
        {
            this.ViewBag.AssignedToUsers = this.Data.Users
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.UserName
                });
        }

    }
}