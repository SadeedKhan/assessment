using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NowAssessment.Domain.Interface.Repositories.Queries.Base;
using NowAssessment.Infrastructure.Data.Context;


namespace NowAssessment.Infrastructure.Repository.Queries.Base
{
    // Generic Query repository class
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        protected readonly NowAssessmentDbContext _dbContext;

        public QueryRepository(NowAssessmentDbContext context)
        {
            _dbContext = context;
        }
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
