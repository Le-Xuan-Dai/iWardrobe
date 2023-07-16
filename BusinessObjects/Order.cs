using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Order : ISoftDelete
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public string DeliverMethod { get; set; }

        public string? DeliverDetais { get; set; }

        public string PaymentMethod { get; set; }

        public string? PaymentDetais { get; set; }

        public string OrderStatus { get; set; }

        public string? Note { get; set; }

        public virtual Product? Product { get; set; }

        public virtual User? User { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
