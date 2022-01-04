using FluentValidation;

namespace EmployeeAPI.Services.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}