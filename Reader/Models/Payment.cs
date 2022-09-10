using System;
using System.Collections.Generic;

namespace Reader.Models
{
    public partial class Payment
    {
        public long PaymentId { get; set; }
        public long? BookId { get; set; }
        public DateTime? PaymentDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public long? UserId { get; set; }

        public virtual Book? Book { get; set; }
        public virtual User? User { get; set; }
    }
}
