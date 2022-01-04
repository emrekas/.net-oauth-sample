using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeAPI.Common.Extensions;
using EmployeeAPI.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Services.Employee.Queries.EmployeeList
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeListModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetEmployeeListQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<EmployeeListModel>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees
                .AsNoTracking()
                .SkipOrAll(request.Skip)
                .TakeOrAll(request.Take)
                .ToListAsync(cancellationToken);
            
            var employeeModel = _mapper.Map<List<Entities.Employee>, List<EmployeeListModel>>(employees);
            
            return employeeModel;
        }
    }
}