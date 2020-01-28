using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestDeloitte.Areas.Identity.Data;
using TestDeloitte.Data;

[assembly: HostingStartup(typeof(TestDeloitte.Areas.Identity.IdentityHostingStartup))]
namespace TestDeloitte.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<TestDeloitteContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("TestDeloitteContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 0;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredUniqueChars = 0;

                    options.User.AllowedUserNameCharacters += " ";
                })
                    .AddEntityFrameworkStores<TestDeloitteContext>();
            });
            //TODO:If I go this way, Configure in Startup is not executed
            //builder.Configure((context, app) =>
            //{
            //    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //    {
            //        var dbContext = serviceScope.ServiceProvider.GetRequiredService<TestDeloitteContext>();
            //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            //        dbContext.Database.EnsureCreated();
            //        userManager.SeedUsers();
            //    }
            //});
        }
    }
}