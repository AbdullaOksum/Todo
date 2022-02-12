using FluentValidation;
using Todo.DTO.DTOs.UrgencyDTOs;

namespace Todo.Business.ValidationRules.FluentValidation
{
    public class UrgencyUpdateValidator : AbstractValidator<UrgencyUpdateDto>
    {
        public UrgencyUpdateValidator()
        {
            RuleFor(x => x.Definition).NotNull().WithMessage("Definition feltet kan ikke være tom");
        }

    }
}
