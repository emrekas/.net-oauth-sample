using System;
using System.Threading.Tasks;
using EmployeeAPI.Services.Employee.Commands.CreateEmployee;
using EmployeeAPI.Services.Employee.Queries.EmployeeList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Authorize]
    public class EmployeesController : ApiControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] CreateEmployeeCommand command)
        {
            var createEmployeeModel = await Mediator.Send(command);

            return Created($"api/employees/{createEmployeeModel.Id}", createEmployeeModel);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get([FromQuery] GetEmployeeListQuery query)
        {
            var employeeListModel = await Mediator.Send(new GetEmployeeListQuery {Take = query.Take, Skip = query.Skip});
            return Ok(employeeListModel);
        }
    }
}