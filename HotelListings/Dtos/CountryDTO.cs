using System.ComponentModel.DataAnnotations;

namespace HotelListings.Dtos
{
    public class CountryDTO:CreateCountryDTO
    {
        public int Id { get; set; }

        public IList<HotelDTO> Hotels { get; set; }
    }

    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name is too long"),]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }

}
