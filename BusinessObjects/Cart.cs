using System;
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
        [ForeignKey("")]
        public int UserID { get; set; }
        [ForeignKey("Post")]
        public int PostID { get; set; }

        public string Note { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
