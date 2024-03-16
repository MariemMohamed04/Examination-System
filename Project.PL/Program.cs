using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.BLL.Repositories;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.PL.Mapper;

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
                     
            #region Identity
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>( options =>
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

            builder.Services.AddScoped<IBranchRepo, BranchRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IInstructorRepo, InstructorRepo>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<ITopicRepo, TopicRepo>();
            builder.Services.AddScoped<IReportsRepo, ReportsRepo>();
            builder.Services.AddScoped<ICrsDeptRepo, CrsDeptRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString("Account/SignIn");
                    options.AccessDeniedPath = new PathString("/Home/Error");
                });

            builder.Services.AddAuthorization();
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(map => map.AddProfile(new MappingProfiles()));

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=SignIn}/{id?}");

            app.Run();
        }
    }
}
