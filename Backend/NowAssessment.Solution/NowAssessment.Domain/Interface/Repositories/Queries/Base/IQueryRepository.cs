namespace NowAssessment.Domain.Interface.Repositories.Queries.Base
{
    public interface IQueryRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByIdAsync(long id);
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}
