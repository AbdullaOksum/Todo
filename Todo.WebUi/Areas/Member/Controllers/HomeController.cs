using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Interface;
using Todo.Entities.Concrete;
using Todo.WebUi.BaseController;
using Todo.WebUi.StringInfo;

namespace Todo.WebUi.Areas.member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class HomeController : BaseIdentityController
    {
        private readonly IReportService _reportService;
        private readonly IAssignmentService _AssignmentService;
        private readonly INotificationService _noification;
        public HomeController(IReportService raporService, UserManager<AppUser> userManager, IAssignmentService AssignmentService, INotificationService bildirimService) : base(userManager)
        {
            _reportService = raporService;
            _AssignmentService = AssignmentService;
            _noification = bildirimService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["active"] = TempDataInfo.Home;

            var user = await LoginUser();

            ViewBag.ReportCount = _reportService.GetReportCountId(user.Id);

            ViewBag.CompletetsignmentCount =
                _AssignmentService.GetAssignmentCompletedCountAppUserId(user.Id);

            ViewBag.NonCompletetAssignmentCount =
                _AssignmentService.GetAssignmentNonCompletedCountAppUserId(user.Id);
            ViewBag.NotificationCount =
                _noification.UnreadCountWithAppUserId(user.Id);

            return View();
        }
    }
}
