using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Interface;
using Todo.Entities.Concrete;
using Todo.WebUi.BaseController;
using Todo.WebUi.StringInfo;

namespace Todo.WebUi.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IAssignmentService _AssignmentService;
        private readonly INotificationService _notificationService;
        private readonly IReportService _reportService;

        public HomeController(IAssignmentService AssignmentService, INotificationService notificationService,
            UserManager<AppUser> userManager, IReportService raporservice) : base(userManager)
        {
            _AssignmentService = AssignmentService;
            _notificationService = notificationService;

            _reportService = raporservice;
        }

        public async Task<IActionResult> Index()
        {
            var user = await LoginUser();
            TempData["Active"] = TempDataInfo.Home;

            ViewBag.AssignmentNonStaff = _AssignmentService.GetAssignmentWithNonStaff();
            ViewBag.CompletetAssignmentCount = _AssignmentService.GetAssignmentCompletedCount();
            ViewBag.UnreadedNotificationCount = _notificationService.ListAllUnread(user.Id).Count();
            ViewBag.ReportCount = _reportService.GetReportCount();
            return View();
        }
    }
}
