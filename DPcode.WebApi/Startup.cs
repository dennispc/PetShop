using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DPcode.Domain.IServices;
using DPcode.Domain.Services;
using DPcode.WebApi.IConverters;
using DPcode.WebApi.Converters;
using DPcode.Core.Models;
using DPcode.Domain.IRepositories;
using DPcode.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using DPcode.Infrastructure.Data;
using Microsoft.Extensions.Logging;

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
            var loggerFactory = LoggerFactory.Create(builder => {
                    builder.AddConsole();
                }
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DPcode.WebApi", Version = "v1" });
            });
            services.AddDbContext<PetShopContext>(
                options =>
                {
                    options
                        .UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=../videoApp.db");
                });
            services.AddScoped<IRepository<Pet>,PetRepository>();
            services.AddScoped<IService<Pet>,PetService>();
            services.AddScoped<IRepository<PetType>, PetTypeRepository>();
            services.AddScoped<IService<PetType>, PetTypeService>();
            services.AddScoped<IRepository<Owner>,OwnerRepository>();
            services.AddScoped<IService<Owner>, OwnerService>();
            services.AddScoped<IPetConverter,PetConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PetShopContext ctx)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DPcode.WebApi v1"));

                ctx.Database.EnsureCreated();
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
