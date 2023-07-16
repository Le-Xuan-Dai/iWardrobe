using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Voucher : ISoftDelete
    {
        [Key]
        public int VoucherId { get; set; }

        [Required]
        [StringLength(255)]
        public string VoucherName { get; set;}

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string Code { get; set;}

        [Required]
        public int Value { get; set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set;}

        [Required]
        public int Quantity { get; set;}

        [ForeignKey("User")]
        public string UserId { get; set;}

        public virtual User? User { get; set;}

        public bool IsDeleted { get; set; } = false;
    }
}
