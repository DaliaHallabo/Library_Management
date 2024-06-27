using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace BookManagement.Models
{
    public class Borrowing
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BorrowingId { get; set; }     
        public DateTime BorrowDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        [ForeignKey("Student")]
        public int studentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("BookCopy")]
        public int CopyId { get; set; }
        public BookCopy Copy { get; set; }

        [ForeignKey("status")]
        public int ReturnStatusId { get; set; }
        public Status ReturnStatus { get; set; }
    }
}
