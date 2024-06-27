using BookManagement.Contracts;
using BookManagement.Data;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagement.Repositories
{
    public class BookCopyRepository : GenericRepository<BookCopy>, IBookCopyRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BookCopyRepository(LibraryDbContext context) : base(context)
        {
            _libraryDbContext = context;
        }

        public async Task<BookCopy> GetBookCopyByIdAsync(int bookCopyId)
        {
            return await _libraryDbContext.BookCopies
                .Include(bc => bc.Status)
                .Include(bc => bc.Book)
                .FirstOrDefaultAsync(bc => bc.Id == bookCopyId);
        }

        public async Task<IEnumerable<BookCopy>> GetAllWithDetailsAsync()
        {
            return await _libraryDbContext.BookCopies
                .Include(bc => bc.Status)
                .Include(bc => bc.Book)
                .ToListAsync();
        }

        public async Task UpdateAsync(BookCopy bookCopy)
        {
            _libraryDbContext.BookCopies.Update(bookCopy);
            await _libraryDbContext.SaveChangesAsync();
        }
    }

    
}
