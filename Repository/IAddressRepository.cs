using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Probeaufgabe.Models;

namespace Probeaufgabe.Repository
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAllAddresses();
        Address GetAddressById(int id);
        Task<string> InsertAddress(Address address);
        Task<string> DeleteAddress(int id);
        Task<string> UpdateAddress(Address address);
       
    }
}
