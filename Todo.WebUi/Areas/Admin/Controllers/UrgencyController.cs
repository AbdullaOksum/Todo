using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Interface;
using Todo.DTO.DTOs.UrgencyDTOs;
using Todo.Entities.Concrete;
using Todo.WebUi.StringInfo;

namespace Todo.WebUi.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _UrgencyService;
        private readonly IMapper _mapper;

        public UrgencyController(IUrgencyService UrgencyService, IMapper mapper)
        {
            _UrgencyService = UrgencyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Urgency;


            return View(_mapper.Map<List<UrgencyListDto>>(_UrgencyService.GetAll()));
        }

        public IActionResult CreateUrgency()
        {
            TempData["Active"] = TempDataInfo.Urgency;

            return View(new UrgencyAddDto());
        }

        [HttpPost]
        public IActionResult CreateUrgency(UrgencyAddDto model)
        {

            if (ModelState.IsValid)
            {
                _UrgencyService.Save(new Urgency()
                {
                    Definition = model.Definition,
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateUrgency(int id)
        {
            TempData["Active"] = TempDataInfo.Urgency;

            return View(_mapper.Map<UrgencyUpdateDto>(_UrgencyService.GetId(id)));

        }
        [HttpPost]
        public IActionResult UpdateUrgency(UrgencyUpdateDto model)
        {
            TempData["Active"] = TempDataInfo.Urgency;
            if (ModelState.IsValid)
            {
                _UrgencyService.Update(new Urgency
                {
                    Id = model.Id,
                    Definition = model.Definition
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }


    }
}
