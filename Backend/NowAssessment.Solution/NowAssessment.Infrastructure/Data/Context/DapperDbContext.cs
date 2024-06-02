using Microsoft.EntityFrameworkCore;

namespace NowAssessment.Infrastructure.Data.Context
{
    internal class DapperDbContext : DbContext
    {
        public DapperDbContext() { }
        public DapperDbContext(DbContextOptions<DapperDbContext> options) : base(options) { }
    }
}
