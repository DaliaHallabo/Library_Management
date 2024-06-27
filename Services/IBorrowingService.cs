using BookManagement.Dtos;

namespace BookManagement.Services
{
    public interface IBorrowingService
    {
        Task<bool> BorrowBookAsync(BorrowingDto borrowingDto);
        Task<bool> ReturnBookAsync(ReturnBookDto returnBookDto);
        Task<IEnumerable<BookCopyReportDto>> GetBookCopyReportAsync();
    }
}
