using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAccessment.Data;
using WebApplicationAccessment.Models;

namespace WebApplicationAccessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly List<Country> countries;
        private readonly List<CountryDetails> countryDetails;

        public PhoneNumberController()
        {
            var dataInitializer = new DataInitializer();
            countries = dataInitializer.InitializeCountries();
            countryDetails = dataInitializer.InitializeCountryDetails();
        }
        [HttpGet("{phoneNumber}")]
        public IActionResult GetCountryDetails(string phoneNumber)
        {
            var countryCode = phoneNumber.Substring(0, 3);

            var country = countries.FirstOrDefault(c => c.CountryCode == countryCode);

            if (country == null)
            {
                return NotFound();
            }

            var countryDetails = this.countryDetails
                .Where(d => d.CountryId == country.Id)
                .Select(d => new { d.Operator, d.OperatorCode })
                .ToList();

            var result = new
            {
                number = phoneNumber,
                country = new
                {
                    countryCode = country.CountryCode,
                    name = country.Name,
                    countryIso = country.CountryIso,
                    countryDetails = countryDetails
                }
            };

            return Ok(result);
        }
    }
}
