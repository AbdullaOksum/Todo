using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Todo.Business.Interface;
using Todo.DTO.DTOs.AssignmentDTOs;
using Todo.Entities.Concrete;
using Todo.WebUi.StringInfo;

namespace Todo.WebUi.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _AssignmentService;
        private readonly IUrgencyService _UrgencyService;
        private readonly IMapper _mapper;

        public AssignmentController(IAssignmentService AssignmentService, IUrgencyService UrgencyService, IMapper mapper)
        {
            _AssignmentService = AssignmentService;
            _UrgencyService = UrgencyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Assignment;




            return View(_mapper.Map<List<AssignmentListDto>>(_AssignmentService.ListUrgencyNonCompleted()));
        }

        public IActionResult CreateAssignment()
        {
            TempData["Active"] = TempDataInfo.Assignment;


            ViewBag.Urgencys = new SelectList(_UrgencyService.GetAll(), "Id", "Definition");
            return View(new AssignmentAddDto());
        }

        [HttpPost]
        public IActionResult CreateAssignment(AssignmentAddDto model)
        {
            TempData["Active"] = TempDataInfo.Assignment;
            if (ModelState.IsValid)
            {
                _AssignmentService.Save(new Assignment
                {
                    Explanation = model.Explanation,
                    Name = model.Name,
                    UrgencyId = model.UrgencyId
                });
                return RedirectToAction("Index");
            }
            ViewBag.Urgencys = new SelectList(_UrgencyService.GetAll(), "Id", "Definition");

            return View(model);

        }

        public IActionResult UpdateAssignment(int id)
        {
            TempData["Active"] = TempDataInfo.Assignment;

            var assignment = _AssignmentService.GetId(id);
            ViewBag.Urgencys = new SelectList(_UrgencyService.GetAll(),
                "Id", "Definition", assignment.UrgencyId);


            return View(_mapper.Map<AssignmentUpdateDto>(assignment));
        }

        [HttpPost]
        public IActionResult UpdateAssignment(AssignmentUpdateDto model)
        {
            TempData["Active"] = TempDataInfo.Assignment;
            if (ModelState.IsValid)
            {
                _AssignmentService.Update(new Assignment()
                {
                    Id = model.Id,
                    Explanation = model.Explanation,
                    UrgencyId = model.UrgencyId,
                    Name = model.Name,

                });
                return RedirectToAction("Index");
            }

            ViewBag.Urgencys = new SelectList(_UrgencyService.GetAll(),
              "Id", "Definition", model.UrgencyId);
            return View(model);
        }

        public IActionResult DeleteAssignment(int id)
        {

            _AssignmentService.Delete(new Assignment { Id = id });
            return Json(null);
        }

    }
}
