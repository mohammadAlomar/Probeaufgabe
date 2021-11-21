using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Probeaufgabe.Models;

namespace Probeaufgabe.Repository
{
     public interface IAddressLink
    {
        IEnumerable<AddressLink> GetAllAddresses();
        List<AddressLink> GetAddressLinkId(int id);
        Task<string> InsertAddressLink(List<AddressLink> addressLinks);
        Task<string> DeleteAddressLink(int id);
        Task<string> UpdateAddressLink(AddressLink addressLink);
      
    }
}
