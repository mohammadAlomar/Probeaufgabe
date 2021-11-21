﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Probeaufgabe.Models;
using Probeaufgabe.ViewModels;

namespace Probeaufgabe.Helper
{
    public class AddressLinksHelper
    {
        public static EditCompanyViewModel ConvertOTD(List<AddressLink> addressLinks)
        {
            
            EditCompanyViewModel editCompanyViewModel = new EditCompanyViewModel
            {
                FirstName = addressLinks[0].Company.FirstName,
                LastName = addressLinks[0].Company.LastName,
                Phone = addressLinks[0].Company.Phone,
                Fax = addressLinks[0].Company.Fax,
                EmailAddress = addressLinks[0].Company.EmailAddress,
                CompanyName = addressLinks[0].Company.CompanyName,
                CompanyNr = addressLinks[0].Company.CompanyNr,
                StrHnrPost = addressLinks[1].Address.StrHnr,
                ZipCodePost = addressLinks[1].Address.ZipCode,
                CityPost = addressLinks[1].Address.City,
                CountryPost = addressLinks[1].Address.Country,

                City = addressLinks[0].Address.City,
                ZipCode = addressLinks[0].Address.ZipCode,
                StrHnr = addressLinks[0].Address.StrHnr,
                Country = addressLinks[0].Address.Country,

            };
            if (addressLinks.Count > 1)
                editCompanyViewModel.AdressType = true;

                return editCompanyViewModel;
        }
    }
}
