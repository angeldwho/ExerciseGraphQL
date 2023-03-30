using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExerciseGraphQL.DAL.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly LibraryDBContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(LibraryDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, int id)
        {
            var existingEntity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (existingEntity != null)
            {
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
                return existingEntity;
            }
            return null;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if(entity != null) {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
                
        }
        public async Task<int> GetCountAsync()
        {
            return await _dbSet.CountAsync();
        }
    }
}