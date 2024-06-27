using BookManagement.Contracts;
using BookManagement.Data;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookManagement.Repositories
{
    public class BorrowingRepository : GenericRepository<Borrowing>, IBorrowingRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BorrowingRepository(LibraryDbContext context) : base(context)
        {
            _libraryDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Borrowing> GetByIdAsync(int borrowingId)
        {
            return await _libraryDbContext.Borrowings
                .Include(b => b.Copy)
                .FirstOrDefaultAsync(b => b.BorrowingId == borrowingId);
        }

        public async Task AddAsync(Borrowing borrowing)
        {
            await _libraryDbContext.Borrowings.AddAsync(borrowing);
            await _libraryDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Borrowing borrowing)
        {
            _libraryDbContext.Borrowings.Update(borrowing);
            await _libraryDbContext.SaveChangesAsync();
        }
    }
}
