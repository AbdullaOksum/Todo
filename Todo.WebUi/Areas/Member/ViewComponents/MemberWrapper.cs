using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.DTO.DTOs.AppUserDTOs;
using Todo.Entities.Concrete;


namespace Todo.WebUi.Areas.Member.ViewComponents
{
    public class MemberWrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public MemberWrapper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            AppUserListDto model = new();
            model.Name = user.Name;
            model.SurName = user.SurName;
            model.Picture = user.Picture;
            model.Email = user.Email;



            return View(model);
        }
    }
}
