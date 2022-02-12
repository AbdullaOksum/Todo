using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.DTO.DTOs.AppUserDTOs;
using Todo.Entities.Concrete;
using Todo.WebUi.BaseController;

namespace Todo.WebUi.Controllers
{
    public class HomeController : BaseIdentityController
    {

        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager)
        {

            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (identityResult.Succeeded)
                    {
                        var roller = await _userManager.GetRolesAsync(user);
                        if (roller.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }

                    }


                }

                ModelState.AddModelError("", "Brugernavnet eller kodeordet er forkert");

            }
            return View("Index", model);
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {

                AppUser user = new()
                {


                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    SurName = model.SurName,

                };




                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, "member");
                    if (addRoleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    AddError(addRoleResult.Errors);

                }
                AddError(result.Errors);

            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index");
        }

        public IActionResult StatusCode(int? code)
        {
            if (code == 404)
            {
                ViewBag.Code = code;
                ViewBag.Message = "Siden findes ikke";
            }

            return View();
        }



        public void Fail()
        {
            throw new Exception("Der skete en fejl");
        }
    }
}