using Aspekt.Application.Dto;

namespace Aspekt.Application.Services
{
    public interface ICompanyService
    {
        int CreateCompany(CompanyDto company); 
        void UpdateCompany(CompanyDto company);
        void DeleteCompany(int companyId);
        List<CompanyDto> GetAll();
    }
}
