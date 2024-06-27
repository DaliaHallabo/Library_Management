using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace BookManagement.Models
{
    public class BookCopy
    {
        public int Id { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }






    }
}
