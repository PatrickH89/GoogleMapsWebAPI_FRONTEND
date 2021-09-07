using GoogleMapsWebAPI_Frontend.Models.Configuration;
using GoogleMapsWebAPI_Frontend.Interfaces;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleMapsWebAPI_Frontend.Models;
using Newtonsoft.Json;

namespace GoogleMapsWebAPI_Frontend.Services
{
    public class AddressService : IAddressService
    {
        AddressConfiguration Config { get; }

        private readonly HttpClient _client;

        public AddressService(HttpClient httpClient, AddressConfiguration adressConfiguration)
        {
            Config = adressConfiguration;
            httpClient.BaseAddress = new Uri(Config.ApiUrl);
            _client = httpClient;
        }

        // GetAddresses
        public async Task<List<AddressAPIModel>> GetAddresses()
        {
            HttpResponseMessage response = await _client.GetAsync("GetAddresses");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var addresses = JsonConvert.DeserializeObject<List<AddressAPIModel>>(data);
                return addresses;
            }
            return null;
        }

        // SelectAddress
        public async Task<AddressAPIModel> SelectAddress(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"SelectAddress/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var address = JsonConvert.DeserializeObject<AddressAPIModel>(data);
                return address;
            }
            return null;
        }

        // CreateAddress
        public async Task<bool> CreateAddress(AddressFormsModel address)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("AddAddress", address);
            return response.IsSuccessStatusCode;
        }

        // UpdateAddress
        public async Task<AddressFormsModel> SelectAddressForInputFields(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"SelectAddress/{id}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                AddressAPIModel addressAPIModel = JsonConvert.DeserializeObject<AddressAPIModel>(content);
                AddressFormsModel addressFormsModel = BuildUpdateSelectionForInputFields(addressAPIModel);
                return addressFormsModel;
            }
            return null;
        }

        public async Task<bool> UpdateAddress(AddressFormsModel address)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync($"UpdateAddress/{address.Id}", address);
            return response.IsSuccessStatusCode;
        }

        private AddressFormsModel BuildUpdateSelectionForInputFields(AddressAPIModel addressAPIModel)
        {
            if (addressAPIModel == null) return null;
            return new AddressFormsModel()
            {
                Country = addressAPIModel?.Country,
                PostCode = addressAPIModel?.PostCode,
                City = addressAPIModel?.City,
                Street = addressAPIModel?.Street,
                StreetNumber = addressAPIModel?.StreetNumber,
                Id = addressAPIModel.Id
            };
        }

        // DeleteAddress
        public async Task<bool> DeleteAddress(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"DeleteAddress/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
