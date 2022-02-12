using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Todo.Business.Interface;
using Todo.WebUi.StringInfo;

namespace Todo.WebUi.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class GraphicController : Controller
    {
        private readonly IAppUserService _appUserService;

        public GraphicController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {

            TempData["Active"] = TempDataInfo.Graphic;
            return View();
        }

        public IActionResult AssignmentCompletedStaff()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.ListMostAssignmentCompletedStaff());


            return Json(jsonString);
        }
        public IActionResult StaffWorkingOnAssignment()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.ListStaffWorkingOnAssignment());


            return Json(jsonString);
        }


    }
}
