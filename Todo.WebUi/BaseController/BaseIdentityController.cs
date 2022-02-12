using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.Entities.Concrete;

namespace Todo.WebUi.BaseController
{
    public class BaseIdentityController : Controller
    {
        protected readonly UserManager<AppUser> _userManager;
        public BaseIdentityController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<AppUser> LoginUser()
        {
            return await _userManager.FindByNameAsync(User.Identity.Name);
        }

        protected void AddError(IEnumerable<IdentityError> errors)
        {
            foreach (var item in errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

    }
}
