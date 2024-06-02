using Microsoft.EntityFrameworkCore;

namespace NowAssessment.Infrastructure.Data.Context
{
    public class NowAssessmentDbContext :DbContext
    {
        public NowAssessmentDbContext(DbContextOptions<NowAssessmentDbContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NowAssessmentDbContext).Assembly);
        }
       
    }
}
