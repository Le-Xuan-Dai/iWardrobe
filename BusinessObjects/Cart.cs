﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User? User { get; set; }
        public virtual List<CartDetail>? CartDetails { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
