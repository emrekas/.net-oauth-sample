using MediatR;

namespace EmployeeAPI.Services.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<CreateEmployeeModel>
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }
}