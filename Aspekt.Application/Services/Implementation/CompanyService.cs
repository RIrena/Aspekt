using Aspekt.Application.Dto;
using Aspekt.Application.Mapper;
using Aspekt.Application.Repositories;
using Aspekt.Domain.Models;

namespace Aspekt.Application.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> companyRepository;

        public CompanyService(IRepository<Company> companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public int CreateCompany(CompanyDto company)
        {
            //var mappedCompany = company.ToDomain();
            //companyRepository.Create(mappedCompany);
            //return mappedCompany.CompanyId;

            var mappedCompany = companyRepository.Create(company.ToDomain());
            return mappedCompany.CompanyId;
        }

        public void UpdateCompany(CompanyDto company)
        {
            companyRepository.Update(company.ToDomain());
        }

        public void DeleteCompany(int companyId)
        {
            companyRepository.Delete(companyId);
        }

        public List<CompanyDto> GetAll()
        {
            var companies = companyRepository.GetAll();
            var companiesDto = new List<CompanyDto>();
            foreach (var item in companies)
            {
                companiesDto.Add(item.ToDto());

            }
            return companiesDto;
        }
    }
}
