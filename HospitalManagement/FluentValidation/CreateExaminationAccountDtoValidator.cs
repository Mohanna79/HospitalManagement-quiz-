using FluentValidation;
using HospitalManagement.Dto;

namespace HospitalManagement.FluentValidation
{
    public class CreateExaminationAccountDtoValidator : AbstractValidator<CreateExaminationAccountDto>
    {
        public CreateExaminationAccountDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.ExamineCode).NotEmpty();
        }
    }
}
