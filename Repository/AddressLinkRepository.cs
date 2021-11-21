using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Probeaufgabe.AppContext;
using Probeaufgabe.Models;

namespace Probeaufgabe.Repository
{
    public class AddressLinkRepository : IAddressLink
    {
        private readonly AppDbContext _appDbContext;
        public AddressLinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> DeleteAddressLink(int id)
        {
            var addressLinks= _appDbContext.AddressLinks.Where(s => s.CompanyId == id)
                .Include(a => a.Address)
                .Include(c => c.Company)
                           .ToList();
            _appDbContext.AddressLinks.RemoveRange(addressLinks);
            await _appDbContext.SaveChangesAsync();
            return "Success";
        }

        public List<AddressLink> GetAddressLinkId(int id)
        {
           return _appDbContext.AddressLinks.Where(s => s.CompanyId == id)
                .Include(a => a.Address)
                .Include(c=>c.Company)
                           .AsNoTracking().ToList();
        }

        public IEnumerable<AddressLink> GetAllAddresses()
        {
            throw new NotImplementedException();
        }

        public async Task<string> InsertAddressLink(List<AddressLink> addressLinks)
        {
            _appDbContext.AddressLinks.AddRange(addressLinks);
            await _appDbContext.SaveChangesAsync();
            return "Success";

        }


        public async Task<string> UpdateAddressLink(AddressLink addressLink)
        {
            //_appDbContext.AddressLinks.UpdateRange(addressLinks);
            _appDbContext.Entry(addressLink).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return "Success";
        }
    }
}
