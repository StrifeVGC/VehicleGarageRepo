using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using VehicleGarage.Domain.Data.Context;
using VehicleGarage.Domain.Data.Repos.Contracts;
using VehicleGarage.Domain.Data.Repos.Implentations;
using VehicleGarage.Infrastructure.Services.Contract;
using VehicleGarage.Infrastructure.Services.Implementation;

namespace VehicleGarage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(opts =>
                    opts.JsonSerializerOptions.IgnoreNullValues = true
                );
            services.AddTransient<IAircraftRepo, AircraftRepo>();
            services.AddTransient<IAircraftService, AircraftService>();
            services.AddDbContext<VehicleGarageContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("VehicleGarageConnectionString")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
