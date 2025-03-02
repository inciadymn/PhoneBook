﻿using Microsoft.AspNetCore.Mvc;
using PhoneBook.BLL.Abstract;
using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.Model.Dto;
using System.Collections.Generic;

namespace PhoneBook.API.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpPost("user/{id:int}")]
        public IActionResult Insert([FromBody] ContactCreateDto contact, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                ResultService<ContactCreateDto> result = contactService.Insert(contact, id);

                if (result.HasError)
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                ResultService<bool> result = contactService.Delete(id);

                if (result.HasError)
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpGet("report")]
        public IActionResult Report()
        {
            if (ModelState.IsValid)
            {
                ResultService<List<ReportDto>> result = contactService.GetReport();

                if (result.HasError)
                {
                    return BadRequest(result.Errors);
                }

                return Ok(result.Data);
            }

            return BadRequest(ModelState);
        }
    }
}
