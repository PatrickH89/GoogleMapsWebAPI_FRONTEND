using GoogleMapsWebAPI_Frontend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleMapsWebAPI_Frontend.Interfaces
{
    public interface IAddressService
    {
        // get all addresses
        Task<List<AddressAPIModel>> GetAddresses();

        // select address
        Task<AddressAPIModel> SelectAddress(int id);

        // add adress
        Task<bool> CreateAddress(AddressFormsModel address);

        // update address
        Task<AddressFormsModel> SelectAddressForInputFields(int id);

        // update bool
        Task<bool> UpdateAddress(AddressFormsModel address);

        // delete address
        Task<bool> DeleteAddress(int id);
    }
}
