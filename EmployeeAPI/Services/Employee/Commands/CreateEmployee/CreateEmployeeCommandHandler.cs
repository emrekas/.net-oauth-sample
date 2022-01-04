using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using EmployeeAPI.Persistence;
using MediatR;

namespace EmployeeAPI.Services.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CreateEmployeeModel> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<CreateEmployeeCommand, Entities.Employee>(request);
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    await _context.Employees.AddAsync(employee, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw new TransactionException(e.Message);
                }
            }
            
            var employeeModel = _mapper.Map<Entities.Employee, CreateEmployeeModel>(employee);
            return employeeModel;
        }
    }
}