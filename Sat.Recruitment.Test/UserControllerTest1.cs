using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api;
using Sat.Recruitment.Api.Controllers;

using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserControllerTest1
    {
        [Fact]
        public void CreateUserSuccess()
        {
            var userController = new UsersController(new UserReader());

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void CreateUserError()
        {
            var userController = new UsersController(new UserReader());

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void ErrorName()
        {
            var userController = new UsersController(new UserReader());

            var result = userController.CreateUser(null, "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.False(result.IsSuccess);
            Assert.Equal("The name is required", result.Errors);
        }

        [Fact]
        public void ErrorEmail()
        {
            var userController = new UsersController(new UserReader());

            var result = userController.CreateUser("Agustina", null, "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.False(result.IsSuccess);
            Assert.Equal("The email is required", result.Errors);
        }

        [Fact]
        public void ErrorAddress()
        {
            var userController = new UsersController(new UserReader());

            var result = userController.CreateUser("Agustina", "mike@gmail.com", null, "+349 1122354215", "Normal", "124").Result;

            Assert.False(result.IsSuccess);
            Assert.Equal("The address is required", result.Errors);
        }

        [Fact]
        public void ErrorPhone()
        {
            var userController = new UsersController(new UserReader());

            var result = userController.CreateUser("Agustina", "mike@gmail.com", "Av. Juan G", null, "Normal", "124").Result;

            Assert.False(result.IsSuccess);
            Assert.Equal("The phone is required", result.Errors);
        }

        [Fact]
        public void AllValidateErrors()
        {
            var userController = new UsersController(new UserReader());

            var result = userController.CreateUser(null, null, null, null, "Normal", "124").Result;

            Assert.False(result.IsSuccess);
            Assert.Equal("The name is required The email is required The address is required The phone is required", result.Errors);
        }


    }
}
