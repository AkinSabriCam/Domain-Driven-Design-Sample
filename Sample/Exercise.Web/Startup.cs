using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Exercise.Application;
using Exercise.Application.Buses;
using Exercise.Application.Companies;
using Exercise.Application.Contracts.Buses;
using Exercise.Application.Contracts.Companies;
using Exercise.Domain.Buses;
using Exercise.Domain.Companies;
using Exercise.EntityFramework.EntityFrameworkCore;
using Exercise.EntityFramework.EntityFrameworkCore.Buses;
using Exercise.EntityFramework.EntityFrameworkCore.Companies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Exercise.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContext<ExerciseDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IBusAppService, BusAppService>();
            services.AddScoped<IBusRepository, EfBusRepository>();

            services.AddScoped<ICompanyRepository, EfCompanyRepository>();
            services.AddScoped<ICompanyAppService, CompanyAppService>();

            services.AddScoped<IDbContext, ExerciseDbContext>();


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ExerciseAutoMapperProfile());
                mc.AddProfile(new ExerciseWebAutoMapperProfile()); 
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        
        
        
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
