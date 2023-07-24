using Aspekt.Application.Dto;

namespace Aspekt.Application.Services
{
    public interface ICountryService
    {
        int CreateCountry(CountryDto country);
        void UpdateCountry(CountryDto country);
        void DeleteCountry(int countryId);
        List<CountryDto> GetAll();
    }
}
