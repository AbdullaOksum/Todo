using FluentValidation;
using Todo.DTO.DTOs.AppUserDTOs;

namespace Todo.Business.ValidationRules.FluentValidation
{
    public class AppUserListValidator : AbstractValidator<AppUserListDto>
    {
        public AppUserListValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Navn feltet kan ikke være tom");
            RuleFor(x => x.SurName).NotNull().WithMessage("Efternavn feltet kan ikke være tom");
        }
    }
}
