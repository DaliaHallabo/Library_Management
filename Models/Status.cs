using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string status { get; set; }

        public ICollection<BookCopy> Copies { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
    }
}

