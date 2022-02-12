using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Interface;
using Todo.DTO.DTOs.NotificationDTOs;
using Todo.Entities.Concrete;
using Todo.WebUi.BaseController;
using Todo.WebUi.StringInfo;

namespace Todo.WebUi.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService bilsirimService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _notificationService = bilsirimService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = TempDataInfo.Notification;

            var user = await LoginUser();


            return View(_mapper.Map<List<NotificationListDto>>(_notificationService.ListAllUnread(user.Id)));
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var updateNotification = _notificationService.GetId(id);
            updateNotification.Situation = true;
            _notificationService.Update(updateNotification);
            return RedirectToAction("Index");
        }

    }
}
