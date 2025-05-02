using FluentValidation;
using SchoolManagemetApi.Domain.DTO.DepartmentDto_s;

namespace SchoolManagemetApi.Domain.Validation
{
    public class CreateDepartmentDtoValidation : AbstractValidator<CreateDepartmentDto>
    {
        public CreateDepartmentDtoValidation()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 100).WithMessage("Name must be between 2-100 characters.");

        }
    }
}
