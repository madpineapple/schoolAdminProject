using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using schoolAdminProj.Areas.Identity.Data;
using schoolAdminProj.Data;

[assembly: HostingStartup(typeof(schoolAdminProj.Areas.Identity.IdentityHostingStartup))]
namespace schoolAdminProj.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<schoolAdminProjContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("schoolAdminProjContextConnection")));

                services.AddDefaultIdentity<schoolAdminProjUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<schoolAdminProjContext>();
            });
        }
    }
}