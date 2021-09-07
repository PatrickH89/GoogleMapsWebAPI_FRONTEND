using System.ComponentModel.DataAnnotations;

namespace GoogleMapsWebAPI_Frontend.Models
{
    public class AddressFormsModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Country")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string Country { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Postcode")]
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        [MaxLength(5, ErrorMessage = "Please enter at most  5 characters.")]
        public string PostCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the City")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Street")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Streetnumber")]
        public string StreetNumber { get; set; }

        public int? Id { get; set; }
    }
}
