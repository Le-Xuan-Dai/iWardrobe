using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Voucher
    {
        [Key]
        public int VoucherId { get; set; }
        public string VoucherName { get; set;}
        [StringLength(8, MinimumLength = 8)]
        public string Code { get; set;}
        public string Value { get; set;}
        public string CreationDate { get; set;}
        public string ExpirationDate { get; set;}
        public int Quantity { get; set;}
        [ForeignKey("User")]
        public int UserId { get; set;}
        public virtual User? User { get; set;}
        public bool IsDeleted { get; set; } = false;
    }
}
