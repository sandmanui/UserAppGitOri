using AutoMapper;
using MemoryCache.Testing.Moq;
using MemoryCache.Testing.Moq.Extensions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserApplication.WebApi.Domain;
using UserApplication.WebApi.Dto;
using UserApplication.WebApi.Repository;
using UserApplication.WebApi.Services;

namespace UserApplication.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IUserRepository> userRepository;
        private UserService userService;
        private Mock<IMapper> mapper;
        private IMemoryCache cache;

        [TestInitialize]
        public void setup()
        {
            userRepository = new Mock<IUserRepository>();
            mapper = new Mock<IMapper>();
            cache = Create.MockedMemoryCache();
            userService = new UserService(userRepository.Object,mapper.Object,cache);
        }

        [TestMethod]
        public async Task ListAsync_ExpectUsersList()
        {
            //arrange
            var cacheEntryKey = "UserList_1";
            IEnumerable<User> userList = GetUsersList();
            IEnumerable<UserDTO> userDTOs = GetUsersDTO();
            
            //set up repository
            userRepository.Setup(m => m.GetAllAsync()).Returns(Task.FromResult(userList));

            //set up mapping service
            mapper.Setup(m => m.Map<IEnumerable<User>, IEnumerable<UserDTO>>(It.IsAny<IEnumerable<User>>())).Returns(userDTOs); // mapping data

            //set up mock caching service
            var mockedCache = Create.MockedMemoryCache();
            mockedCache.SetUpCacheEntry(cacheEntryKey, userList);

            //act
            var result = await userService.ListAsync();

            // Assert
            Assert.AreEqual(userDTOs, result);
        }
               
        private static IEnumerable<User> GetUsersList()
        {
            return new List<User>() {
                new User{Id=1,Name="TestUser",Address=new Address{City="testCity",Street="testStreet",Suite="testSuite",Zipcode="1234"}} };
        }

        private static IEnumerable<UserDTO> GetUsersDTO()
        {
            return new List<UserDTO>() {
                new UserDTO{Id=1,Name="TestUser",City="testcity",Street="testStreet",Suite="testSuite",Zipcode="1234",Lat="123",Lng="123"}
            };
        }
    }
}
