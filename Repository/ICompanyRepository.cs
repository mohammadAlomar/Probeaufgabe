using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Probeaufgabe.Models;

namespace Probeaufgabe.Repository
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies();
        Company GetCompanyById(int id);
        Task<string> InsertCompany(Company company);
        Task<string> DeleteCompany(int id);
        Task<string> UpdateCompany(Company company);
 
    }
}
