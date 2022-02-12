using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Interface;
using Todo.DTO.DTOs.AppUserDTOs;
using Todo.Entities.Concrete;


namespace Todo.WebUi.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public Wrapper(UserManager<AppUser> userManager, INotificationService bildirimService, IMapper mapper)
        {
            _userManager = userManager;
            _notificationService = bildirimService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var identityUser = _userManager.FindByNameAsync
                (User.Identity.Name).Result;

            var model = _mapper.Map<AppUserListDto>
                (_userManager.FindByNameAsync(User.Identity.Name).Result);

            ViewBag.NotificationCount = _notificationService.ListAllUnread(model.Id).Count;

            var roles = _userManager.GetRolesAsync(identityUser).Result;
            if (roles.Contains("Admin"))
            {
                return View(model);
            }
            return View("Member", model);
        }
    }
}
