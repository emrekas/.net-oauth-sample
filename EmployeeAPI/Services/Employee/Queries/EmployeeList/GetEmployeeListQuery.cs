using System.Collections.Generic;
using MediatR;

namespace EmployeeAPI.Services.Employee.Queries.EmployeeList
{
    public class GetEmployeeListQuery : IRequest<List<EmployeeListModel>>
    {
        public int? Take { get; set; }
        public int? Skip { get; set; }
    }
}