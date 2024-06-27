using AutoMapper;
using BookManagement.Contracts;
using BookManagement.Dtos;
using BookManagement.Models;


namespace BookManagement.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IMapper _mapper;
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly IStatusRepository _statusRepository;

        public BorrowingService(IMapper mapper, IBookCopyRepository bookCopyRepository, IBorrowingRepository borrowingRepository, IStatusRepository statusRepository)
        {
            _mapper = mapper;
            _bookCopyRepository = bookCopyRepository;
            _borrowingRepository = borrowingRepository;
            _statusRepository = statusRepository;
        }

        public enum StatusEnum
        {
            Available = 1,
            Borrowed = 3,
            // Add other statuses as needed
        }

        public async Task<bool> BorrowBookAsync(BorrowingDto borrowingDto)
        {
            try
            {
                // Ensure the book copy exists before proceeding
                var bookCopy = await _bookCopyRepository.GetBookCopyByIdAsync(borrowingDto.BookCopyId);
                if (bookCopy == null)
                {
                    Console.WriteLine($"Book copy with ID {borrowingDto.BookCopyId} not found.");
                    return false;
                }
                if (bookCopy.StatusId == (int)StatusEnum.Borrowed)
                {
                    Console.WriteLine($"Book copy with ID {borrowingDto.BookCopyId} is already borrowed.");
                    return false;
                }

                // Ensure the status exists before proceeding
                var status = await _statusRepository.GetStatusByIdAsync((int)StatusEnum.Borrowed);
                if (status == null)
                {
                    Console.WriteLine($"Status with ID {(int)StatusEnum.Borrowed} not found.");
                    return false;
                }

                // Update the status of the book copy
                bookCopy.StatusId = (int)StatusEnum.Borrowed; // Assuming StatusEnum.Borrowed represents "Borrowed"
                await _bookCopyRepository.UpdateAsync(bookCopy);

                var borrowing = _mapper.Map<Borrowing>(borrowingDto);
                borrowing.BorrowDate = DateTime.Now;
                borrowing.Copy = bookCopy; // Assign the BookCopy entity
                borrowing.ReturnStatus = status; // Assign the Borrowing status

                await _borrowingRepository.AddAsync(borrowing);

                return true;
            }
            catch (Exception ex)
            {
                // Log and handle exceptions
                Console.WriteLine($"Exception in BorrowBookAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ReturnBookAsync(ReturnBookDto returnBookDto)
        {
            try
            {
                var borrowing = await _borrowingRepository.GetByIdAsync(returnBookDto.BorrowingId);
                if (borrowing == null)
                {
                    Console.WriteLine($"Borrowing record with ID {returnBookDto.BorrowingId} not found.");
                    return false;
                }

                if (borrowing.ActualReturnDate != null)
                {
                    Console.WriteLine($"Book with ID {borrowing.CopyId} has already been returned.");
                    return false;
                }

                if (borrowing.ReturnStatusId != (int)StatusEnum.Borrowed)
                {
                    Console.WriteLine($"Book with ID {borrowing.CopyId} is not currently borrowed.");
                    return false;
                }

                borrowing.ActualReturnDate = DateTime.Now;
                borrowing.ReturnStatusId = returnBookDto.StatusId;

                await _borrowingRepository.UpdateAsync(borrowing);

                var bookCopy = await _bookCopyRepository.GetBookCopyByIdAsync(borrowing.CopyId);
                if (bookCopy != null)
                {
                    bookCopy.StatusId = returnBookDto.StatusId;
                    await _bookCopyRepository.UpdateAsync(bookCopy);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in ReturnBookAsync: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<BookCopyReportDto>> GetBookCopyReportAsync()
        {
            var bookCopies = await _bookCopyRepository.GetAllWithDetailsAsync();

            var report = bookCopies.Select(b => new BookCopyReportDto
            {
                BookTitle = b.Book.Title,
                CopyId = b.Id,
                Statuses = new List<string> { b.Status.status }
            });

            return report;
        }
    }
}
