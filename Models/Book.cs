namespace BookManagement.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<BookCopy> Copies { get; set; }
    }
}
