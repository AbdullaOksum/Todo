using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Interface;
using Todo.DTO.DTOs.AssignmentDTOs;
using Todo.DTO.DTOs.ReportDTOs;
using Todo.Entities.Concrete;
using Todo.WebUi.BaseController;
using Todo.WebUi.StringInfo;

namespace Todo.WebUi.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class WorkInProgressController : BaseIdentityController
    {

        private readonly IAssignmentService _AssignmentService;
        private readonly IReportService _reportService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public WorkInProgressController(IAssignmentService AssignmentService,
           UserManager<AppUser> userManager, IReportService reportService, INotificationService notificationService, IMapper mapper) : base(userManager)
        {
            _AssignmentService = AssignmentService;
            _reportService = reportService;
            _notificationService = notificationService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {

            TempData["active"] = TempDataInfo.WorkInProgress;
            var user = await LoginUser();
            return View(_mapper.Map<List<AssignmentListAllDto>>(_AssignmentService.GetAllProperty(i => i.AppUserId == user.Id && !i.Situation)));
        }

        public IActionResult AddReport(int id)
        {
            TempData["active"] = TempDataInfo.WorkInProgress;


            var assignment = _AssignmentService.GetUrgencyWithId(id);

            ReportAddDto model = new()
            {
                AssignmentId = id,
                Assignment = assignment
            };



            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddDto model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report()
                {
                    AssignmentId = model.AssignmentId,
                    Detail = model.Detail,
                    Definition = model.Definition
                });

                var adminuserList = await _userManager.GetUsersInRoleAsync("Admin");
                var activeUser = await LoginUser();
                foreach (var admin in adminuserList)
                {
                    _notificationService.Save(new Notification()
                    {
                        Explanation = $"{activeUser.Name} {activeUser.SurName} " +
                        $"har skrevet en ny Raport.",
                        AppUserId = admin.Id,


                    });
                };



                return RedirectToAction("Index");
            }

            return View(model);
        }


        public IActionResult UpdateReport(int id)
        {
            TempData["active"] = TempDataInfo.WorkInProgress;


            return View(_mapper.Map<ReportUpdateDto>(_reportService.GetWithAssignmentId(id)));
        }

        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var updatedReport = _reportService.GetId(model.Id);
                updatedReport.Definition = model.Definition;
                updatedReport.Detail = model.Detail;

                _reportService.Update(updatedReport);
                return RedirectToAction("Index");
            }

            return View(model);

        }

        public async Task<IActionResult> CompleteAssignment(int AssignmentId)
        {
            var updateAssignment = _AssignmentService.GetId(AssignmentId);
            updateAssignment.Situation = true;
            _AssignmentService.Update(updateAssignment);

            var adminuserList = await _userManager.GetUsersInRoleAsync("Admin");
            var activeUser = await LoginUser();
            foreach (var admin in adminuserList)
            {
                _notificationService.Save(new Notification()
                {
                    Explanation = $"{activeUser.Name} {activeUser.SurName} " +
                    $"har har færdiggjordt opgaven.",
                    AppUserId = admin.Id,


                });
            }
            return Json(null);




        }
    }
}
