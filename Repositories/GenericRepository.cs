using BookManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly LibraryDbContext _db;
        private readonly DbSet<TEntity> _dbSet;


        public GenericRepository(LibraryDbContext db)
        {
            _db = db ;
            _dbSet = _db.Set<TEntity>();

        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }


        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _db.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
       
    

    }


}

