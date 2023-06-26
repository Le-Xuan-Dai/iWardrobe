using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User? User { get; set; }

        public virtual Product? Product { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
