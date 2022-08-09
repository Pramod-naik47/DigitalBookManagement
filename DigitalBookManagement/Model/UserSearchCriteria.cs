namespace DigitalBookManagement.Model
{
    public class UserSearchCriteria
    {
        public long BookId { get; set; }
        public byte[]? Logo { get; set; }
        public string? BookTitle { get; set; }
        public string? Category { get; set; }
        public decimal? Price { get; set; }
        public long? UserId { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublistDate { get; set; }
    }
}
