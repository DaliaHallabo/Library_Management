using BookManagement.Models;
using BookManagement.Repositories;

namespace BookManagement.Contracts
{
    public interface IStatusRepository:IGenericRepository<Status>
    {
        Task<Status> GetStatusByIdAsync(int id);

    }
}
