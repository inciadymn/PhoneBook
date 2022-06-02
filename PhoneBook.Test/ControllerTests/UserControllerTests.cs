using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PhoneBook.API.Controllers;
using PhoneBook.BLL.Abstract;
using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PhoneBook.Test.ControllerTests
{
    public class UserControllerTests
    {
        [Fact]
        public void UserController_Insert_ShouldReturnOk()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();

            var request = new UserDto()
            {
                FirstName = "test",
                LastName = "test",
                Company = "test"
            };

            userServiceMock
                .Setup(a => a.Insert(request))
                .Returns(new ResultService<UserDto>()
                {
                    Data = request,
                    HasError = false
                });

            var userController = CreateInstance(userServiceMock);

            //Act
            var result = userController.Insert(request);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        private UserController CreateInstance(Mock<IUserService> userServiceMock)
        {
            var userController = new UserController(userServiceMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            return userController;
        }
    }
}
