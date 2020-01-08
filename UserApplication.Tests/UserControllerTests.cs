
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserApplication.WebApi.Controllers;
using UserApplication.WebApi.Dto;
using UserApplication.WebApi.Services;

namespace UserApplication.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        private Mock<IUserService> userService;
        private UserController userController;

        [TestInitialize]
        public void setup()
        {
            userService = new Mock<IUserService>();
            userController = new UserController(userService.Object);
        }

        [TestMethod]
        public async Task GetUsers_ExpectSuccess()
        {
            //arrange
            IEnumerable<UserDTO> userList = GetUsersList();
            userService.Setup(m => m.ListAsync()).Returns(Task.FromResult(userList));

            //act
            var getUsersResult = await this.userController.GetUsers();
            var actionResult = getUsersResult as ObjectResult;
            var contentResult = actionResult.Value;

            //Assert
            //check if ok result getting
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            //check return content is same as provided by service layer
            Assert.AreEqual(contentResult, userList);

        }

        private static IEnumerable<UserDTO> GetUsersList()
        {
            return new List<UserDTO>() {
                new UserDTO{Id=1,Name="TestUser",City="testcity",Street="testStreet",Suite="testSuite",Zipcode="1234",Lat="123",Lng="123"}
            };
        }
    }
}
