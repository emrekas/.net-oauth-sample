using AutoMapper;
using EmployeeAPI.Services.Employee.Commands.CreateEmployee;
using EmployeeAPI.Services.Employee.Queries.EmployeeList;

namespace EmployeeAPI.Common.Mapping
{
    public class EmployeeProfiles : Profile
    {
        public EmployeeProfiles()
        {
            CreateMap<CreateEmployeeCommand, Entities.Employee>();
            CreateMap<Entities.Employee, CreateEmployeeModel>();
            CreateMap<Entities.Employee, EmployeeListModel>();
        }
    }
}