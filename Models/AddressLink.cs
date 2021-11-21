using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Probeaufgabe.Models
{
    public class AddressLink
    {
        public int AddressLinkID { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
        [MaxLength(4)]
        [Required]
        public string AdressType { get; set; }
    }
}
