using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Probeaufgabe.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [MaxLength(255)]
        [Required]
        public string StrHnr { get; set; }
        [MaxLength(10)]
        [Required]
        public string ZipCode { get; set; }
        [MaxLength(100)]
        [Required]
        public string City { get; set; }
        [MaxLength(150)]
        [Required]
        public string Country { get; set; }
        public virtual ICollection<AddressLink> Companies { get; set; }
    }
}
