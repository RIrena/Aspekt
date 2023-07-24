using Aspekt.Application.Dto;
using Aspekt.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpPost("create")]
        public ActionResult CreateContact([FromBody] ContactDto contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            contactService.CreateContact(contact);
            return Created("api/contact", contact);
        }

        [HttpPut("update")]
        public ActionResult UpdateContact([FromBody] ContactDto contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            contactService.UpdateContact(contact);
            return Created("api/contact", contact);
        }

        [HttpDelete("delete/{contactId}")]
        public ActionResult DeleteContact(int contactId)
        {
            contactService.DeleteContact(contactId);
            return Created("api/contact", contactId);
        }

        [HttpGet("getAllContacts")]
        public ActionResult<List<ContactDto>> GetAll()
        {
            return Ok(contactService.GetAll());
        }

        [HttpGet("getContactsWithCompanyAndCountry")]
        public ActionResult <List<ContactDto>> GetContactsWithCompanyAndCountry(string companyName, string countryName)
        {
            return Ok(contactService.GetContactsWithCompanyAndCountry(companyName, countryName));
        }

        [HttpGet("filterContacts/{companyId?}/{countryId?}")]
        public ActionResult <List<ContactDto>> FilterContact(int companyId, int countryId)
        {
            return Ok(contactService.FilterContact(companyId, countryId));
        }
    }
}
