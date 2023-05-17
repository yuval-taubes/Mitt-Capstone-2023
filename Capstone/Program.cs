using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Capstone.Domain;
using Capstone.Areas.Identity.Data;

namespace Capstone
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("CapstoneContextConnection") ?? throw new InvalidOperationException("Connection string 'CapstoneContextConnection' not found.");

            builder.Services.AddDbContext<CapstoneContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<CapstoneUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<CapstoneContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            //github test
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "Teacher", "Student" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
            //just seeding one admin user
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<CapstoneUser>>();
                string email = "admin@admin.com";
                string password = "Pass123!";
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new CapstoneUser();
                    user.UserName = email;
                    user.Email = email;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "Admin");

                    //Hello
                }
            }
            app.Run();

        }
    }
}