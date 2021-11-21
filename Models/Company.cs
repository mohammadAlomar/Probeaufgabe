using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Probeaufgabe.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        [MaxLength(60)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(255)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(255)]
        [Required]
        public string CompanyName { get; set; }
        [MaxLength(8)]
        [Required]
        public string CompanyNr { get; set; }
        [Required]
        public int Phone { get; set; }
        public int? Fax { get; set; }
        [MaxLength(255)]
        [Required]
        public string EmailAddress { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual ICollection<AddressLink> Addresses { get; set; }
    }
}
