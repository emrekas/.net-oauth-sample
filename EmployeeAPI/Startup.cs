using EmployeeAPI.Common.Extensions;
using EmployeeAPI.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmployeeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = "https://localhost:2001";
                    options.Audience = "Employee";
                });
            services.AddAutoMapper(typeof(Startup));
            // services.
            services.AddMediatR(typeof(Startup));
            services.AddControllers(options =>
                    options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(fv => { fv.RegisterValidatorsFromAssemblyContaining(typeof(Startup)); });
            // services.AddControllers();
            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=AuthEmployee.db", b => b.MigrationsAssembly("AuthEmployee.EmployeeAPI")));
            services.AddSwaggerGen(
                c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeAPI", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}