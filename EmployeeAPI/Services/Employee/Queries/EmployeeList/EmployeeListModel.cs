using System;
using System.Linq.Expressions;

namespace EmployeeAPI.Services.Employee.Queries.EmployeeList
{
    public class EmployeeListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        
        public static Expression<Func<Entities.Employee, EmployeeListModel>> Projection
        {
            get
            {
                return employee => new EmployeeListModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Title = employee.Title
                };
            }
        }
    }
}