using Microsoft.EntityFrameworkCore;

namespace NowAssessment.Infrastructure.Data.Context
{
    public class NowAssessmentDbContext : DbContext
    {
        public NowAssessmentDbContext(DbContextOptions<NowAssessmentDbContext> options)
           : base(options)
        {
        }
    }
}
