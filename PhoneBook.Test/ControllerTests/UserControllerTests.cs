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

        [Fact]
        public void UserController_Insert_ShouldReturnBadRequest()
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
                    Data = null,
                    HasError = true,
                    Errors = new List<ErrorItem>()
                    {
                        new ErrorItem()
                        {
                            ErrorType="Insert Error",
                            ErrorMessage ="Add not successful",
                        }
                    }
                });

            var userController = CreateInstance(userServiceMock);

            //Act
            var result = userController.Insert(request);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UserController_Delete_ShouldReturnOk()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>(); 

            userServiceMock
                .Setup(a => a.Delete(1))
                .Returns(new ResultService<bool>()
                {
                    Data = true,
                    HasError=false,
                });

            var userController = CreateInstance(userServiceMock);

            //Act
            var result = userController.Delete(1);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UserController_Delete_ShouldReturnBadRequest()
        {
            var userServiceMock = new Mock<IUserService>();

            userServiceMock
                .Setup(a => a.Delete(1))
                .Returns(new ResultService<bool>()
                {
                    Data=false,
                    HasError=true,
                    Errors= new List<ErrorItem>()
                    {
                        new ErrorItem()
                        {
                            ErrorType="Deletion Error", 
                            ErrorMessage="Deletion failed"
                        }
                    }
                });

            var userController = CreateInstance(userServiceMock);

            var result = userController.Delete(1);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UserController_Update_ShouldReturnOk()
        {
            var userServiceMock = new Mock<IUserService>();

            var request = new UserDto()
            {
                FirstName = "test",
                LastName = "test",
                Company = "test"
            };

            userServiceMock
                .Setup(a => a.Update(request, 1))
                .Returns(new ResultService<bool>()
                {
                    Data = true,
                    HasError = false,
                });

            var userController = CreateInstance(userServiceMock);

            var result = userController.Update(request, 1);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UserController_GetAllUsers_ShouldReturnOk()
        {
            var userServiceMock = new Mock<IUserService>();

            userServiceMock
                .Setup(a => a.GetAllUsers())
                .Returns(new ResultService<List<GetAllUserDto>>()
                {
                    Data = new List<GetAllUserDto>()
                    {
                        new GetAllUserDto()
                        {
                            ID=1,
                            FirstName="test",
                            LastName="test",
                            Company="test"
                        }
                    },
                    HasError = false,
                });

            var userController = CreateInstance(userServiceMock);

            var result = userController.GetAll();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UserController_GetUserContacts_ShouldReturnOk()
        {
            var userServiceMock = new Mock<IUserService>();

            userServiceMock
                .Setup(a => a.GetUserContacts(1))
                .Returns(new ResultService<GetUserContactsDto>()
                {
                    Data = new GetUserContactsDto() 
                    {
                        ID=1,
                        FirstName="test",
                        LastName="test",
                        Company="test"
                    },
                    HasError = false
                });

            var userController = CreateInstance(userServiceMock);

            var result = userController.GetUserContacts(1);

            Assert.IsType<OkObjectResult>(result);
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
