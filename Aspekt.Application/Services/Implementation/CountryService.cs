using Aspekt.Application.Dto;
using Aspekt.Application.Mapper;
using Aspekt.Application.Repositories;
using Aspekt.Domain.Models;

namespace Aspekt.Application.Services.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> countryRepository;

        public CountryService(IRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public int CreateCountry(CountryDto country)
        {
            var mappedCompany = countryRepository.Create(country.ToDomain());
            return mappedCompany.CountryId;
        }

        public void UpdateCountry(CountryDto country)
        {
            countryRepository.Update(country.ToDomain());
        }

        public void DeleteCountry(int countryId)
        {
            countryRepository.Delete(countryId);
        }

        public List<CountryDto> GetAll()
        {
            var countries = countryRepository.GetAll();
            var countriesDto = new List<CountryDto>();
            foreach (var item in countries)
            {
                countriesDto.Add(item.ToDto());

            }
            return countriesDto;
        }
    }
}
