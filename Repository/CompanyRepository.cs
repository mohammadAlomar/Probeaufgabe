using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Probeaufgabe.AppContext;
using Probeaufgabe.Models;

namespace Probeaufgabe.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _appDbContext;
        public CompanyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> DeleteCompany(int id)
        {
            var company = _appDbContext.Companies.FirstOrDefault(i=>i.CompanyId==id);
            _appDbContext.Companies.Remove(company);
            await _appDbContext.SaveChangesAsync();
            return "Success";

        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _appDbContext.Companies.ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _appDbContext.Companies.Where(s => s.CompanyId ==id)
                           .Include(s => s.Addresses)
                           .FirstOrDefault();
        }

        public async Task<string> InsertCompany(Company company)
        {
            _appDbContext.Companies.Add(company);
            await _appDbContext.SaveChangesAsync();
            return "Success";

        }


        public async Task<string> UpdateCompany(Company company)
        {
            _appDbContext.Entry(company).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return "Success";
        }
    }
}
