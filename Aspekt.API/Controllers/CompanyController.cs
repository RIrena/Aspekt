using Aspekt.Application.Dto;
using Aspekt.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpPost("create")]
        public ActionResult CreateCompany([FromBody] CompanyDto company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //400

            companyService.CreateCompany(company);
            return Created("api/company", company); //201

            //companyService.CreateCompany(company);
            //return StatusCode(StatusCodes.Status201Created, "Sucesfully created new company");
        }

        [HttpPut("update")]
        public ActionResult UpdateCompany([FromBody] CompanyDto company)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            companyService.UpdateCompany(company);
            return Created("api/company", company);
        }

        [HttpDelete("delete/{companyId}")]
        public ActionResult DeleteCompany(int companyId)
        {
            companyService.DeleteCompany(companyId);
            return Created("api/company", companyId);
        }

        [HttpGet("getAllCompanies")]
        public ActionResult <List<CompanyDto>> GetAll()
        {
            return Ok(companyService.GetAll());

            //var companies = companyService.GetAll();
            //return Created("api/company", companies);
        }
    }
}
