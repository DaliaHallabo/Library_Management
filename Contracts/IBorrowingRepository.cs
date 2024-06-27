using BookManagement.Dtos;
using BookManagement.Models;
using BookManagement.Repositories;

namespace BookManagement.Contracts
{
    public interface IBorrowingRepository:IGenericRepository<Borrowing>
    {
         Task<Borrowing> GetByIdAsync(int borrowingId);
        Task AddAsync(Borrowing borrowing);
        Task UpdateAsync(Borrowing borrowing);
    }
}
