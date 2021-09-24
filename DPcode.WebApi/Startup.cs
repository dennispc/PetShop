using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DPcode.Domain.IServices;
using DPcode.Infrastructure.Data.IRepositories;
using DPcode.Domain.Services;
using DPcode.Infrastructure.Data.Repositories;
using DPcode.WebApi.IConverters;
using DPcode.WebApi.Converters;
using DPcode.Core.Models;

namespace DPcode.WebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DPcode.WebApi", Version = "v1" });
            });
            services.AddScoped<IFakeDB, FakeDB>();
            services.AddScoped<IRepository<PetType>, PetTypeRepository>();
            services.AddScoped<IService<PetType>, PetTypeService>();
            services.AddScoped<IRepository<Owner>,OwnerRepository>();
            services.AddScoped<IService<Owner>, OwnerService>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IPetConverter,PetConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DPcode.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
