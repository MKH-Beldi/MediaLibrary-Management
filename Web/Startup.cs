using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PS.Data.Infrastructure;
using PS.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace Web
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
            var hostdb = Configuration["DBHOST"] ?? "localhost";
            var portdb = Configuration["DBPORT"] ?? "3306";
            var userdb = Configuration["DBUSER"] ?? "root";
            var passworddb = Configuration["DBPASSWORD"] ?? "";
            services.AddControllersWithViews();
            services.AddDbContextFactory<Context>(
                options =>
                {
                    options.UseMySQL($"server={hostdb};user={userdb};pwd={passworddb};"
                    + $"port={portdb};database=medialibrary");
                });
            services.AddScoped<IAudioService, AudioService>()
                .AddScoped<IBookService, BookService>()
                .AddScoped<IBorrowService, BorrowService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IClientService, ClientService>()
                .AddScoped<IDocumentService, DocumentService>()
                .AddScoped<IMediaLibraryService, MediaLibraryService>()
                .AddScoped<IVideoService, VideoService>()
             .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IDataBaseFactory, DataBaseFactory>()
            .AddScoped<DbContext, Context>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataBaseFactory context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            context.DataContext.Database.Migrate();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
