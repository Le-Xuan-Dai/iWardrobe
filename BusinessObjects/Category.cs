using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Category : ISoftDelete
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string CategoryName { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        
        public virtual User? User { get; set; }
        
        public virtual List<Product>? Products { get; set; }
        
        public bool IsDeleted { get; set; } = false;
    }
}
