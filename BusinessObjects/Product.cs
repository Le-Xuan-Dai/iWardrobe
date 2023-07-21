using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Product : ISoftDelete
    {
        [Key]
        public int ProductId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public string Description { get; set; }

        public string[] ImageUrls { get; set; }

        [Required]
        public double SellPrice { get; set; }
        [Required]
        public double RentPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public virtual Category? Category { get; set; }
        
        public virtual User? User { get; set; }
        
        public virtual List<Comment>? Commnents { get; set; }
        
        public virtual List<Favorite>? Favorites { get; set; }

        public virtual List<Order>? Orders { get; set; }
        
        public virtual List<CartDetail>? CartDetails { get; set; }
        
        public bool IsDeleted { get; set; } = false;
    }
}
