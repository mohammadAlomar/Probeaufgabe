using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Probeaufgabe.Models;
using Probeaufgabe.ViewModels;

namespace Probeaufgabe.Helper
{
    public class AddressHelper
    {
        public static Address ConvertDTO(RegistrationCompanyViewModel model,string addressType)
        {
            var address = new Address();
            if (addressType == "post")
            {
                
                address.StrHnr = model.StrHnrPost;
                address.ZipCode = model.ZipCodePost;
                address.City = model.CityPost;
                address.Country = model.CountryPost;

            }
            else
            {
                address.StrHnr = model.StrHnr;
                address.ZipCode = model.ZipCode;
                address.City = model.City;
                address.Country = model.Country;
            }
            return address;
        }
        public static Address ConvertDTO(EditCompanyViewModel model, string addressType, Address address )
        {
           
            if (addressType == "post")
            {
                
                address.StrHnr = model.StrHnrPost;
                address.ZipCode = model.ZipCodePost;
                address.City = model.CityPost;
                address.Country = model.CountryPost;

            }
            else
            {
               
                address.StrHnr = model.StrHnr;
                address.ZipCode = model.ZipCode;
                address.City = model.City;
                address.Country = model.Country;
            }
            return address;
        }
    }
}
