namespace BookManagement.Dtos
{
    public class BookCopyReportDto
    {
        public string BookTitle { get; set; }
        public int CopyId { get; set; }
        public List<string> Statuses { get; set; }
    }
}
