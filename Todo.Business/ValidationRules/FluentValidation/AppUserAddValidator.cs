using FluentValidation;
using Todo.DTO.DTOs.AppUserDTOs;

namespace Todo.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {

            RuleFor(x => x.UserName).NotNull().WithMessage("Brugernavn feltet kan ikke være tom");
            RuleFor(x => x.Password).NotNull().WithMessage("Kodeord feltet kan ikke være tom");
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Gentag kodeord feltet kan ikke være tom");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Kodeordene er ikke ens");
            RuleFor(x => x.Email).NotNull().WithMessage("Email feltet kan ikke være tom");
            RuleFor(x => x.Name).NotNull().WithMessage("Navn feltet kan ikke være tom");
            RuleFor(x => x.SurName).NotNull().WithMessage("Efternavn feltet kan ikke være tom");

        }
    }
}

