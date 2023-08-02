using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace E_commerce
{
    public class AddressController : ApiController
    {

        static readonly AddressRepository addressRepository = new AddressRepository();


        public IEnumerable<Address> GetAllAddresses()
        {
            return addressRepository.GetAddresses();
        }

        public Address GetAddress(int id)
        {
            Address address= addressRepository.GetAddress(id);
            if (address == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return address;
        }


        public HttpResponseMessage PostProduct(Address address)
        {
            address = addressRepository.AddAddress(address);
            var response = Request.CreateResponse<Address>(HttpStatusCode.Created, address);
            string uri = Url.Link("DefaultApi", new { id = address.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutProduct(int id, Address address)
        {
            address.Id = id;
            if (!addressRepository.UpdateAddress(address))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteProduct(int id)
        {
            addressRepository.DeleteAddress(id);
        }
    }
}