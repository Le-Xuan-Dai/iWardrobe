using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        [EmailAddress]
        [StringLength(320, MinimumLength = 6)]
        public string Email { get; set; }
        public string Address { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual List<Product>? Products { get; set; }
        public virtual List<Order>? Orders { get; set; }
        public virtual Cart? Cart { get; set; }
        public virtual Role? Role { get; set; }
        public virtual List<Voucher>? Vouchers { get; set; }
        public virtual List<Category>? Categories { get; set; }
        public virtual List<Commnent>? Comments { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
