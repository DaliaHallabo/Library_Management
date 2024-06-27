namespace BookManagement.Dtos
{
    public class BorrowingDto
    {
        public int StudentId { get; set; }
        public int BookCopyId { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }
}
