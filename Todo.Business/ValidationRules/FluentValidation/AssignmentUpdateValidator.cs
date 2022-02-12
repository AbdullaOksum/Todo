using FluentValidation;
using Todo.DTO.DTOs.AssignmentDTOs;

namespace Todo.Business.ValidationRules.FluentValidation
{
    public class AssignmentUpdateValidator : AbstractValidator<AssignmentUpdateDto>
    {
        public AssignmentUpdateValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Opgave navn kan ikke være tom");
            RuleFor(x => x.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Venligst valg en haste tilstand");

        }
    }
}
