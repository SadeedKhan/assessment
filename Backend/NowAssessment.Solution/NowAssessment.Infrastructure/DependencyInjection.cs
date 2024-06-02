using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NowAssessment.Domain.Interface.Repositories.Commands.Base;
using NowAssessment.Domain.Interface.Repositories.Queries.Base;
using NowAssessment.Domain.Interface.Services;
using NowAssessment.Infrastructure.Data.Context;
using NowAssessment.Infrastructure.Identity;
using NowAssessment.Infrastructure.Repository.Commands.Base;
using NowAssessment.Infrastructure.Repository.Queries.Base;
using NowAssessment.Infrastructure.Services;

namespace NowAssessment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<NowAssessmentDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
            ));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).
                AddRoles<IdentityRole>()
           .AddEntityFrameworkStores<IdentityDbContext>()
           .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false; // For special character
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            });

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));

            return services;
        }
    }
}
