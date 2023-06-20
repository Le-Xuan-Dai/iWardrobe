﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Commnent
    {
        [Key]
        public int CommnentId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Message { get; set; }

        public virtual User? User { get; set; }

        public virtual Product? Product { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
