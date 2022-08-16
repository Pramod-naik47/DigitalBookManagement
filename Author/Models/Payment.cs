﻿namespace Author.Models
{
    public partial class Payment
    {
        public long PaymentId { get; set; }
        public string? Email { get; set; }
        public long? UserId { get; set; }
        public long? BookId { get; set; }
        public DateTime? PaymentDate { get; set; }

        public virtual Book? Book { get; set; }
        public virtual User? User { get; set; }
    }
}