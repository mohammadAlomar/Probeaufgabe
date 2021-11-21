using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Probeaufgabe.Models;
using Probeaufgabe.ViewModels;

namespace Probeaufgabe.Helper
{
    public  class CompanyHelper
    {

        public static Company ConvertDTO(RegistrationCompanyViewModel model)
        {

            var company = new Company
            {
                CompanyName = model.CompanyName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                Fax = model.Fax,
                EmailAddress = model.EmailAddress,
                CompanyNr = Guid.NewGuid().ToString().Substring(0, 8),
                

            };
            return company;
        }
        public static Company ConvertDTO(EditCompanyViewModel model)
        {
          
            var company = new Company
            {
                CompanyId=model.CompanyId,
                CompanyName = model.CompanyName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                Fax = model.Fax,
                EmailAddress = model.EmailAddress,
                CompanyNr = model.CompanyNr,

            };
            return company;
        }

    }
}
