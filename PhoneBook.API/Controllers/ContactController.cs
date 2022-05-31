using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.BLL.Abstract;
using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
    [Route("api/user/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpPost("{id:int}")]
        public IActionResult Insert([FromBody]ContactDto contact, [FromRoute]int id)
        {
            if (ModelState.IsValid)
            {
                ResultService<ContactDto> result = contactService.Insert(contact, id);

                if (result.HasError)
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}
