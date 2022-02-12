using FluentValidation;
using Todo.DTO.DTOs.ReportDTOs;

namespace Todo.Business.ValidationRules.FluentValidation
{
    public class ReportUpdateValidator : AbstractValidator<ReportUpdateDto>
    {
        public ReportUpdateValidator()
        {
            RuleFor(x => x.Definition).NotNull().WithMessage("Definition feltet kan ikke være tom");
            RuleFor(x => x.Detail).NotNull().WithMessage("Detalje feltet kan ikke være tom");

        }
    }
}
