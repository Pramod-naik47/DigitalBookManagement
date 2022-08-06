﻿using System;
using System.Collections.Generic;

namespace DigitalBookManagement.Model
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            Books = new HashSet<Book>();
            Payments = new HashSet<Payment>();
        }

        public long UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserType { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
