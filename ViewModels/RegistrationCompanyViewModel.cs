using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Probeaufgabe.ViewModels
{
    public class RegistrationCompanyViewModel
    {

        [Required]
        [Display(Name = "Vorname")]
        [MaxLength(60)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Nachname")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Telefonnummer")]
        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        public int Phone { get; set; }

        
        [Display(Name = "Fax")]
        [DataType(DataType.PhoneNumber)]
        public int? Fax { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [Required]
        [Display(Name = "StrHnr")]
        [MaxLength(255)]
        public string StrHnr { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "Plz")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Ort")]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Land")]
        [MaxLength(150)]
        public string Country { get; set; }

        [Display(Name = "main Address unterscheiden vom Postal Address")]
        public bool AdressType { get; set; }
        [MaxLength(255)]
        [Display(Name = "StrHnr_Post")]
        public string StrHnrPost { get; set; }

        [MaxLength(10)]
        [Display(Name = "Plz_Post")]
        [DataType(DataType.PostalCode)]
        public string ZipCodePost { get; set; }
        [Display(Name = "Ort_Post")]
        [MaxLength(100)]
        public string CityPost { get; set; }

        [Display(Name = "Land_Post")]
        [MaxLength(150)]
        public string CountryPost { get; set; }
    }
}
