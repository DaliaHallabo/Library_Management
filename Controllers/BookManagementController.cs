using AutoMapper;
using BookManagement.Contracts;
using BookManagement.Dtos;
using BookManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookManagementController : ControllerBase
    {
        private readonly IBorrowingService _borrowingService;

        public BookManagementController(IBorrowingService borrowingService, IMapper mapper)
        {
            _borrowingService = borrowingService;
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowingDto borrowingDto)
        {
            var result = await _borrowingService.BorrowBookAsync(borrowingDto);
            if (!result)
            {
                return BadRequest("Failed to borrow the book.");
            }
            return Ok("Book borrowed successfully.");
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnBook([FromBody] ReturnBookDto returnBookDto)
        {
            var result = await _borrowingService.ReturnBookAsync(returnBookDto);
            if (!result)
            {
                return BadRequest("Failed to return the book.");
            }
            return Ok("Book returned successfully.");
        }
    

    [HttpGet("report")]
        public async Task<IActionResult> GetBookCopyReport()
        {
            var report = await _borrowingService.GetBookCopyReportAsync();
            return Ok(report);
        }
    }
}
