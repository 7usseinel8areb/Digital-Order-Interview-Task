using DigitalOrder.Infrastructure.Data;
using DigitalOrder.Infrastructure.InfrastructureBases.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DigitalOrder.Infrastructure.InfrastructureBases.Implementation
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        //virtual keyword used following the oop pillar polymorphism to override this methods

        public virtual async Task<bool> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            bool succedded = await SaveChangesAsync();

            return succedded;
        }

        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await SaveChangesAsync();
        }

        public virtual async Task DeleteRangeAsync(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
            await _context.SaveChangesAsync();
        }


        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetTablAsTracking()
        {
            return _context.Set<T>().AsTracking().AsQueryable();
        }

        public IQueryable<T> GetTableNoTracking()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
            _context.Set<T>().Update(entity);

            return await SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
            await SaveChangesAsync();
        }
    }
}
