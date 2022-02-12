using FluentValidation;
using Todo.DTO.DTOs.ReportDTOs;

namespace Todo.Business.ValidationRules.FluentValidation
{
    public class ReportAddValidation : AbstractValidator<ReportAddDto>
    {
        public ReportAddValidation()
        {
            RuleFor(x => x.Detail).NotNull().WithMessage("Detalje feltet kan ikke være tom");
            RuleFor(x => x.Definition).NotNull().WithMessage("Detalje feltet kan ikke være tom");
        }



    }
}
