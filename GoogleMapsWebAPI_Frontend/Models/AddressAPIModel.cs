using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GoogleMapsWebAPI_Frontend.Models
{
    public class AddressAPIModel
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Latitude { get; set; } // Breitengrad

        public string Longitude { get; set; } // Längengrad

        [Range(minimum: 1, maximum: 99999, ErrorMessage = "Please enter a valid nr between 0 & 99999")]
        public int Id { get; set; }

    }
}
