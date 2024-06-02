using Microsoft.EntityFrameworkCore;
using NowAssessment.Domain.Interface.Repositories.Commands.Base;
using NowAssessment.Infrastructure.Data.Context;

namespace NowAssessment.Infrastructure.Repository.Commands.Base
{
    // Generic command repository class
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly NowAssessmentDbContext _context;

        public CommandRepository(NowAssessmentDbContext context)
        {
            _context = context;
        }

        // Insert
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Update
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
