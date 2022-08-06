using System;
using System.Collections.Generic;

namespace DigitalBookManagement.Model
{
    public partial class Payment
    {
        public long PaymentId { get; set; }
        public string? Email { get; set; }
        public long? UserId { get; set; }
        public long? BookId { get; set; }
        public DateTime? PaymentDate { get; set; }

        public virtual Book? Book { get; set; }
        public virtual UserDetail? User { get; set; }
    }
}
