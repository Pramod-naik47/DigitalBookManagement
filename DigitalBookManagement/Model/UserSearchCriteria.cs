namespace DigitalBookManagement.Model
{
    public class UserSearchCriteria
    {
        public long BookId { get; set; }
        public byte[]? Logo { get; set; }
        public string BookTitle { get; set; } = null!;
        public string? Category { get; set; }
        public decimal? Price { get; set; }
        public long? UserId { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublistDate { get; set; }
        public string? Content { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
    }
}
