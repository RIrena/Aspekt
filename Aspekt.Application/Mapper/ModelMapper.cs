using Aspekt.Application.Dto;
using Aspekt.Domain.Models;
using AutoMapper;

namespace Aspekt.Application.Mapper
{
    public static class ModelMapper
    {
        // ================ COMPANY =================
        public static Company ToDomain(this CompanyDto dtoModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CompanyDto, Company>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<Company>(dtoModel);
        }

        public static CompanyDto ToDto(this Company dtoModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyDto>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<CompanyDto>(dtoModel);
        }

        // ================ COUNTRY =================
        public static Country ToDomain(this CountryDto dtoModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CountryDto, Country>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<Country>(dtoModel);
        }

        public static CountryDto ToDto(this Country dtoModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Country, CountryDto>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<CountryDto>(dtoModel);
        }

        // ================ CONTACT =================
        public static Contact ToDomain(this ContactDto dtoModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ContactDto, Contact>();
                cfg.CreateMap<CompanyDto, Company>();
                cfg.CreateMap<CountryDto, Country>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<Contact>(dtoModel);
        }

        public static ContactDto ToDto(this Contact dtoModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contact, ContactDto>();
                cfg.CreateMap<Country, CountryDto>();
                cfg.CreateMap<Company, CompanyDto>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper.Map<ContactDto>(dtoModel);
        }
    }
}
