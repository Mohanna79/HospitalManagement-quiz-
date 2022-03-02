using FluentValidation;
using HospitalManagement.Dto;

namespace HospitalManagement.FluentValidation
{
    public class CreateDoctorAccountDtoValidator : AbstractValidator<CreateDoctorAccountDto>
    {
        public CreateDoctorAccountDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.MedicalSystemCode).GreaterThanOrEqualTo(4).WithMessage("کد نظام پزشکی باید 4 رقمی باشد");
        }
    }
}
