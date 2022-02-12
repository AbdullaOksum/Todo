using FluentValidation;
using Todo.DTO.DTOs.AppUserDTOs;

namespace Todo.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Brugernavn feltet kan ikke være tom");
            RuleFor(x => x.Password).NotNull().WithMessage("Kodeord feltet kan ikke være tom");




        }
    }
}
