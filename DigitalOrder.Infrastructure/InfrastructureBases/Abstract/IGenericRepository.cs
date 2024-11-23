using Microsoft.EntityFrameworkCore.Storage;

namespace DigitalOrder.Infrastructure.InfrastructureBases.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<bool> SaveChangesAsync();

        IDbContextTransaction BeginTransaction();

        void Commit();

        void RollBack();

        //For read-only queries
        IQueryable<T> GetTableNoTracking();

        //For writing / modifing queries
        IQueryable<T> GetTablAsTracking();

        Task<bool> AddAsync(T entity);

        Task AddRangeAsync(ICollection<T> entities);

        Task<bool> UpdateAsync(T entity);

        Task UpdateRangeAsync(ICollection<T> entities);

        Task<bool> DeleteAsync(T entity);

        Task DeleteRangeAsync(ICollection<T> entities);
    }
}
