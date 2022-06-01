using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PhoneBook.API.Controllers;
using PhoneBook.BLL.Abstract;
using PhoneBook.BLL.Concrete.ResultServiceBLL;
using PhoneBook.Model.Dto;
using PhoneBook.Model.Enums;
using Xunit;

namespace PhoneBook.Test.ControllerTests
{
    public class ContactControllerTests
    {
        [Fact]
        public void ContactController_Insert_ShouldReturnOk_WithExpectedValues()
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
                    HasError = false
                });

            var contactController = CreateInstance(contactServiceMock);

            //Act
            var result = contactController.Insert(request, 1);

            //Assert
            Assert.IsType<OkResult>(result);
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
