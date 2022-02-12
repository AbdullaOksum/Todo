using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Interface;
using Todo.DTO.DTOs.AssignmentDTOs;
using Todo.Entities.Concrete;
using Todo.WebUi.BaseController;
using Todo.WebUi.StringInfo;

namespace Todo.WebUi.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class FinishedAssignmentController : BaseIdentityController
    {
        private readonly IAssignmentService _AssignmentService;

        private readonly IMapper _mapper;

        public FinishedAssignmentController(IAssignmentService AssignmentService,
            UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _AssignmentService = AssignmentService;

            _mapper = mapper;
        }



        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["active"] = TempDataInfo.FinishedAssignment;
            var user = await LoginUser();


            var Assignments = _mapper.Map<List<AssignmentListAllDto>>(
                _AssignmentService.GetAllPropertyNonCompleted(out int totalPage,
                user.Id, activePage));

            ViewBag.TotalPage = totalPage;
            ViewBag.ActivePage = activePage;

            return View(Assignments);
        }
    }
}
