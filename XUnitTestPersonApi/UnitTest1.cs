using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PersonApi.Controllers;
using PersonApi.Interfaces;
using PersonApi.Models;
using PersonApi.Repositories;
using PersonApi.Services;
using System;
using Xunit;

namespace XUnitTestPersonApi
{
    public class UnitTest1
    {
        PeopleController _personController;
        AuthenticateController _authController;
        IPersonService _service;
        IPersonManagement _repo;
        public UnitTest1(IServiceProvider provider, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _repo = new PersonManagement(provider);
            _service = new PersonService(_repo);
            _authController = new AuthenticateController(userManager, roleManager, configuration);
            _personController = new PeopleController(_service);
        }

        [Fact]
        public void Enrol_ReturnsOkResult()
        {
            var enrol = _authController.Enrol(new EnrolModel { Email = "tobbyioa@gmail.com", Password = "banana@IOA$1", Username = "tobbyioa" });
            Assert.IsType<OkObjectResult>(enrol.Result);
        } 
        [Fact]
        public void login_ReturnsOkResult()
        {

            var login = _authController.Login(new LoginModel  { Password = "banana@IOA$1", Username = "tobbyioa" });
            Assert.IsType<OkObjectResult>(login.Result);
            
        }

        [Fact]
        public void GetAll_Returns401Result()
        {
            // Act
            var authorizedResult = _personController.GetAll() ;
            // Assert
            Assert.IsType<UnauthorizedResult>(authorizedResult.Result);
        }
    }
}
