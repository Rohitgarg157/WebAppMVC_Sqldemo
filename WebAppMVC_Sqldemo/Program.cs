using Microsoft.EntityFrameworkCore;
using WebAppMVC_Sqldemo.Models;

namespace WebAppMVC_Sqldemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            // Add services to the container.
            var cs = builder.Configuration.GetConnectionString("EmployeeDBConnection");
            builder.Services.AddDbContextPool<AppdbContext>(con => con.UseSqlServer(cs));

            builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
           // builder.Services.AddSingleton<IEmployeeRepository>();
            //builder.Services.AddSingleton<IDepartmentRepository>();

            var app = builder.Build();           // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            

            app.Run();
        }
    }
}