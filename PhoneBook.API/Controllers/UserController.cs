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
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Insert(UserDto user)
        {
            if (ModelState.IsValid)
            {
                ResultService<UserDto> result = userService.Insert(user);

                if (result.HasError)
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromBody]UserDto user, [FromRoute]int id)
        {
            if (ModelState.IsValid)
            {
                ResultService<bool> result = userService.Update(user,id);

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
                ResultService<bool> result = userService.Delete(id);

                if (result.HasError)
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ResultService<List<GetAllUserDto>> result = userService.GetAllUsers();
            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUserContacts([FromRoute]int id)
        {
            ResultService<GetUserContactsDto> result = userService.GetUserContacts(id);

            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }
    }
}
