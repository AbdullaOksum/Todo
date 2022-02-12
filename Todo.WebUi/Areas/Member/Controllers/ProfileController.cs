using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Todo.DTO.DTOs.AppUserDTOs;
using Todo.Entities.Concrete;
using Todo.WebUi.BaseController;
using Todo.WebUi.StringInfo;

namespace Todo.WebUi.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class ProfileController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        public ProfileController(UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = TempDataInfo.profile;

            return View(_mapper.Map<AppUserListDto>(await LoginUser()));
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                var UpdateUser = _userManager.Users.FirstOrDefault(x => x.Id == model.Id);

                if (picture != null)
                {
                    string extension = Path.GetExtension(picture.FileName);
                    string pictureName = Guid.NewGuid() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/img/" + pictureName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await picture.CopyToAsync(stream);
                    }

                    UpdateUser.Picture = pictureName;
                }
                UpdateUser.Name = model.Name;
                UpdateUser.SurName = model.SurName;
                UpdateUser.Email = model.Email;

                var result = await _userManager.UpdateAsync(UpdateUser);
                if (result.Succeeded)
                {
                    TempData["message"] = "Opdatering er gennemførst";
                    return RedirectToAction("Index");
                }
                AddError(result.Errors);
            }
            return View(model);
        }
    }
}
