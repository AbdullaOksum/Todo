using FluentValidation;
using Todo.DTO.DTOs.UrgencyDTOs;

namespace Todo.Business.ValidationRules.FluentValidation
{
    public class urgencyAddValidator : AbstractValidator<UrgencyAddDto>
    {
        public urgencyAddValidator()
        {
            RuleFor(x => x.Definition).NotNull().WithMessage("Definition feltet kan ikke være tom");
        }
    }
}
