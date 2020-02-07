using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.Rpa.Domain.Interfaces.IManagers;
using Services.Rpa.Domain.Interfaces.IRepositories;
using Services.Rpa.Infrastructure.Managers;
using Services.Rpa.Infrastructure.Repositories;
using Services.Rpa.MetadataDbContext;

namespace RpaSolutionAPI
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

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<RpaContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RPA API", Version = "v1" });
            });

            services.AddTransient<IOpenAppManager, OpenAppManager>();
            services.AddTransient<ICloseAppManager, CloseAppManager>();
            services.AddTransient<ISaveAppManager, SaveAppManager>();
            services.AddTransient<IWriteAppManager, WriteAppManager>();

            services.AddTransient<IOpenAppRepository, OpenAppRepository>();
            services.AddTransient<ICloseAppRepository, CloseAppRepository>();
            services.AddTransient<ISaveAppRepository, SaveAppRepository>();
            services.AddTransient<IWriteAppRepository, WriteAppRepository>();

            services.AddTransient<RpaContext>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RPA API V1");
                c.RoutePrefix = "swagger/ui";
            });

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
