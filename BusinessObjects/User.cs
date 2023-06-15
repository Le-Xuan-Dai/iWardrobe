using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(20)]
        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(20)]
        [Required]
        public string Password { get; set; }
    }
}
