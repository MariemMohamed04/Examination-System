using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.BLL.Repositories;
using Project.DAL.Context;
using Project.DAL.Entities;

namespace Project.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Connection To DB
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn"));
            });
            #endregion

            builder.Services.AddControllersWithViews();

            #region Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>( options =>
            {
                #region Password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;
                #endregion

                #region SignIn
                options.SignIn.RequireConfirmedAccount = false;
                #endregion

            }).AddEntityFrameworkStores<AppDbContext>().AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);
            #endregion

            builder.Services.AddScoped<IinstructorRepo, instructorRepo>();
            builder.Services.AddScoped<IstudentRepo, StudentRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=SignUp}/{id?}");

            app.Run();
        }
    }
}
