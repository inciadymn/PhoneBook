using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PhoneBook.API.Controllers;
using PhoneBook.BLL.Abstract;
using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.Model.Dto;
using PhoneBook.Model.Enums;
using System.Collections.Generic;
using Xunit;

namespace PhoneBook.Test.ControllerTests
{
    public class ContactControllerTests
    {
        [Fact]
        public void ContactController_Insert_ShouldReturnOk()
        {
            //Arrange
            var contactServiceMock = new Mock<IContactService>();

            var request = new ContactCreateDto()
            {
                InfoContent = "istanbul",
                InfoType = InfoType.Location.ToString()
            };

            contactServiceMock
                .Setup(a => a.Insert(request, 1))
                .Returns(new ResultService<ContactCreateDto>()
                {
                    Data = request,
                    HasError = false,
                });

            var contactController = CreateInstance(contactServiceMock);

            //Act
            var result = contactController.Insert(request, 1);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void ContactController_Insert_ShouldReturnBadRequest()
        {
            //Arrange
            var contactServiceMock = new Mock<IContactService>();

            var request = new ContactCreateDto()
            {
                InfoContent = "istanbul",
                InfoType = "abc"
            };

            contactServiceMock
                .Setup(a => a.Insert(request, 1))
                .Returns(new ResultService<ContactCreateDto>()
                {
                    Data = null,
                    HasError = true,
                    Errors = new List<ErrorItem>()
                    {
                       new ErrorItem()
                       {
                           ErrorType="Insert Error",
                           ErrorMessage ="InfoType is not valid"
                       }
                    }
                });

            var contactController = CreateInstance(contactServiceMock);

            //Act
            var result = contactController.Insert(request, 1);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void ContactController_Delete_ShouldReturnOk()
        {
            //Arrange
            var contactServiceMock = new Mock<IContactService>();

            contactServiceMock
                .Setup(a => a.Delete(1))
                .Returns(new ResultService<bool>()
                {
                    Data = true,
                    HasError = false
                });

            var contactController = CreateInstance(contactServiceMock);

            //Act
            var result = contactController.Delete(1);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void ContactController_Report_ShouldReturnOk()
        {
            //Arrange
            var contactServiceMock = new Mock<IContactService>();

            contactServiceMock
                .Setup(a => a.GetReport())
                .Returns(new ResultService<List<ReportDto>>()
                {
                    Data = new List<ReportDto>()
                    {
                        new ReportDto()
                        {
                            Location = "istanbul",
                            LocationCount = 1,
                            NumberCount = 1,
                            UserCount = 1
                        }
                    },
                    HasError = false
                });

            var contactController = CreateInstance(contactServiceMock);

            //Act
            var result = contactController.Report();

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        private ContactController CreateInstance(Mock<IContactService> contactServiceMock)
        {
            var contactController = new ContactController(contactServiceMock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            return contactController;
        }
    }
}
