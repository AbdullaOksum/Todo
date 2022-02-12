using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Interface;
using Todo.DTO.DTOs.NotificationDTOs;
using Todo.Entities.Concrete;
using Todo.WebUi.BaseController;
using Todo.WebUi.StringInfo;

namespace Todo.WebUi.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notification;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notification, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _notification = notification;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Notification;

            var user = await LoginUser();

            return View(_mapper.Map<List<NotificationListDto>>(_notification.ListAllUnread(user.Id)));
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var guncellenecekBilgi = _notification.GetId(id);
            guncellenecekBilgi.Situation = true;
            _notification.Update(guncellenecekBilgi);
            return RedirectToAction("Index");
        }

    }
}
