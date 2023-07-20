using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class User : IdentityUser, ISoftDelete
    {
        [StringLength(50)]
        public string Fullname { get; set; }

        [StringLength(50)]
        public string BrandName { get; set; }

        public string Address { get; set; }

        public string Avatar { get; set; }

        [StringLength(12, MinimumLength = 12)]
        public string IdentificationCode { get; set; }

        public string[] IdentificationCardImgs { get; set; }

        public virtual List<Product>? Products { get; set; }

        public virtual List<Order>? Orders { get; set; }

        public virtual List<CartDetail>? CartDetails { get; set; }

        public virtual List<Voucher>? Vouchers { get; set; }

        public virtual List<Category>? Categories { get; set; }

        public virtual List<Comment>? Comments { get; set; }

        public virtual List<Favorite>? Favorites { get; set; }

        public bool IsDeleted { get; set; }
    }
}
