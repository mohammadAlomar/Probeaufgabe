using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Probeaufgabe.AppContext;
using Probeaufgabe.Models;

namespace Probeaufgabe.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _appDbContext;
        public AddressRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> DeleteAddress(int id)
        {
            var address = _appDbContext.Addresses.FirstOrDefault(i => i.AddressId == id);
            _appDbContext.Addresses.Remove(address);
            await _appDbContext.SaveChangesAsync();
            return "Success";
        }

        public Address GetAddressById(int id)
        {
            return _appDbContext.Addresses.FirstOrDefault(a => a.AddressId == id);
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            throw new NotImplementedException();
        }

        public async Task<string> InsertAddress(Address address)
        {
            _appDbContext.Addresses.Add(address);
            await _appDbContext.SaveChangesAsync();
            return "Success";

        }


        public async Task<string> UpdateAddress(Address address)
        {
            _appDbContext.Entry(address).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return "Success";
        }
    }
}
