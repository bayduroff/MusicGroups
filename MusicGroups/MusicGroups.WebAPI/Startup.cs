using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MusicGroups.BLL.Contracts;
using MusicGroups.BLL.Implementation;
using MusicGroups.DataAccess.Context;
using MusicGroups.DataAccess.Contracts;
using MusicGroups.DataAccess.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Npgsql.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MusicGroups.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            //BLL
            services.Add(new ServiceDescriptor(typeof(IClubCreateService),typeof(ClubCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IClubGetService),typeof(ClubGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IClubUpdateService),typeof(ClubUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGroupCreateService),typeof(GroupCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGroupGetService),typeof(GroupGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGroupUpdateService),typeof(GroupUpdateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IReservationCreateService),typeof(ReservationCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IReservationGetService),typeof(ReservationGetService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IReservationUpdateService),typeof(ReservationUpdateService), ServiceLifetime.Scoped));
            
            //DataAccess
            services.Add(new ServiceDescriptor(typeof(IClubDataAccess), typeof(ClubDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IGroupDataAccess), typeof(GroupDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IReservationDataAccess), typeof(ReservationDataAccess), ServiceLifetime.Transient));
            
            //DB Contexts
            // services.AddDbContext<ClubContext>(options =>
            //     options.UseSqlServer(this.Configuration.GetConnectionString("Clubs")));
            services.AddDbContext<ClubContext>(options =>
                options.UseNpgsql(this.Configuration.GetConnectionString("Clubs")));
            // services.AddDbContext<ClubContext>(options =>
            //     options.UseSqlServer("Host=localhost;Port=5432;Database=dotNet;Username=postgres;Password=admin"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ClubContext>();
                context.Database.EnsureCreated(); 
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}