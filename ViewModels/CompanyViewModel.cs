using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Probeaufgabe.ViewModels
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }

        [MaxLength(255)]
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [MaxLength(8)]
        [Required]
        public string CompanyNr { get; set; }

        [MaxLength(255)]
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
     
    }
}
