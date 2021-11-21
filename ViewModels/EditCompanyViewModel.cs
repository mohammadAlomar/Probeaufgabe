using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Probeaufgabe.ViewModels
{
    public class EditCompanyViewModel : RegistrationCompanyViewModel
    {
        [MaxLength(8)]
        [Required]
        
        public string CompanyNr { get; set; }
        public int CompanyId { get; set; }
        public int AddressId { get; set; }
        public int AddressLinkID { get; set; }
    }
}
