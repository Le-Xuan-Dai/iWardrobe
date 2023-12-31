﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CartDetail : ISoftDelete
    {
        [Key]
        public int CartDetailId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public virtual User? User { get; set; }

        public virtual Product? Product { get; set; }
        public bool IsDeleted { get; set; }
    }
}
