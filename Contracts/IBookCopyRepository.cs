using BookManagement.Models;
using BookManagement.Repositories;

namespace BookManagement.Contracts
{
    public interface IBookCopyRepository:IGenericRepository<BookCopy>
    {
        Task<BookCopy> GetBookCopyByIdAsync(int bookCopyId);
        Task<IEnumerable<BookCopy>> GetAllWithDetailsAsync();
        Task UpdateAsync(BookCopy bookCopy);


    }
}

