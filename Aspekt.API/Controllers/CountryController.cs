using Aspekt.Application.Dto;
using Aspekt.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpPost("create")]
        public ActionResult CreateCountry (CountryDto country)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            countryService.CreateCountry(country);
            return Created("api/country", country);
            //return StatusCode(StatusCodes.Status201Created, "Sucesfully added new country!!!");
        }

        [HttpPut("update")]
        public ActionResult UpdateCountry([FromBody] CountryDto country)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            countryService.UpdateCountry(country);
            return Created("api/country", country);
        }

        [HttpDelete("delete/{countryId}")]
        public ActionResult DeleteCountry(int countryId)
        {
            countryService.DeleteCountry(countryId);
            return Created("api/country", countryId);
        }

        [HttpGet("getAllCountries")]
        public ActionResult<List<CountryDto>> GetAll()
        {
            var countries = countryService.GetAll();
            return Created("api/company", countries);
        }
    }
}
