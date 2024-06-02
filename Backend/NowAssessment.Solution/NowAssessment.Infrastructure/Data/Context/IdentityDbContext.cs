using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NowAssessment.Infrastructure.Identity;

namespace NowAssessment.Infrastructure.Data.Context
{
    public class IdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options):base(options) { }
    }
}
