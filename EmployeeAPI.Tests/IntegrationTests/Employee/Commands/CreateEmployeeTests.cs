using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using EmployeeAPI.Services.Employee.Commands.CreateEmployee;
using EmployeeAPI.Tests.IntegrationTests.Extensions;
using Xunit;

namespace EmployeeAPI.Tests.IntegrationTests.Employee.Commands
{
    public class CreateEmployeeTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateEmployeeTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void ShouldCreateEmployee()
        {
            var authorizedClient = SystemTestExtension.GetTokenAuthorizeHttpClient(_factory);
            var command = new CreateEmployeeCommand
            {
                Name = "Emre",
                Title = "Software Developer"
            };
            
            var employeeJson = new StringContent(
                JsonSerializer.Serialize(command),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            
            using var httpResponseMessage =
                await authorizedClient.PostAsync("https://localhost:5001/api/Employees", employeeJson);

            Assert.Equal(HttpStatusCode.Created, httpResponseMessage.StatusCode);
            httpResponseMessage.EnsureSuccessStatusCode();
        }
    }
}