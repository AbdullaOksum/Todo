using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Interface;
using Todo.DTO.DTOs.AppUserDTOs;
using Todo.DTO.DTOs.AssignmentDTOs;
using Todo.DTO.DTOs.ReportDTOs;
using Todo.Entities.Concrete;
using Todo.WebUi.StringInfo;

namespace Todo.WebUi.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class WorkOrderController : Controller
    {
        private readonly IFileService _fileService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAssignmentService _AssignmentService;
        private readonly IAppUserService _appUserService;
        private readonly INotificationService _notification;
        private readonly IMapper _mapper;

        public WorkOrderController(IAppUserService appUserService, IAssignmentService AssignmentService,
            UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService, IMapper mapper)
        {
            _AssignmentService = AssignmentService;
            _appUserService = appUserService;
            _userManager = userManager;
            _fileService = fileService;
            _notification = notificationService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Workorder;
            return View(_mapper.Map<List<AssignmentListAllDto>>(_AssignmentService.GetAllProperty()));
        }

        public IActionResult AssignStaff(int id, string s, int page = 1)
        {
            TempData["Active"] = TempDataInfo.Workorder;

            ViewBag.ActivePage = page;

            ViewBag.Search = s;

            ViewBag.staff = _mapper.Map<List<AppUserListDto>>(_appUserService.ListNonAdmins(out int totalPage, s, page));
            ViewBag.totalPage = totalPage;


            return View(_mapper.Map<AssignmentListDto>(_AssignmentService.GetUrgencyWithId(id)));

        }

        [HttpPost]
        public IActionResult AssignStaff(AssignStaffDto model)
        {
            var assignmentToUpdate = _AssignmentService.GetId(model.AssignmentId);
            assignmentToUpdate.AppUserId = model.PersonelId;

            _AssignmentService.Update(assignmentToUpdate);

            _notification.Save(new Notification
            {
                AppUserId = model.PersonelId,
                Explanation = $"{assignmentToUpdate.Name} er blevet tildelt denne opgave"
            });

            return RedirectToAction("Index");
        }

        public IActionResult AssigntmentToStaff(AssignStaffDto model)
        {
            TempData["Active"] = TempDataInfo.Workorder;
            ListAssignStaffDto dto = new();
            dto.AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(x => x.Id == model.PersonelId));
            dto.Assignment = _mapper.Map<AssignmentListDto>(_AssignmentService.GetUrgencyWithId(model.AssignmentId));

            return View(dto);
        }


        public IActionResult Detail(int id)
        {
            TempData["Active"] = TempDataInfo.Workorder;
            return View(_mapper.Map<AssignmentListAllDto>(_AssignmentService.GetReportId(id)));
        }

        public IActionResult GetExcel(int id)
        {
            return File(_fileService.ChangeToExcel(_mapper.Map<List<ReportFileDto>>
                (_AssignmentService.GetReportId(id).Reports)),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }

        public IActionResult GetPdf(int id)
        {
            var path = _fileService.ChangeToPdf(_mapper.Map<List<ReportFileDto>>
              (_AssignmentService.GetReportId(id).Reports));
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }

    }




}
