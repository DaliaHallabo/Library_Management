using BookManagement.Contracts;
using BookManagement.Data;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Repositories
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        private readonly LibraryDbContext _libraryDbContext;

        public StatusRepository(LibraryDbContext context) : base(context)
        {
            _libraryDbContext = context;
        }

        public async Task<Status> GetStatusByIdAsync(int id)
        {
            return await _libraryDbContext.Statuses.FindAsync(id);
        }
    }
}