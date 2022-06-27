using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api;
using Xunit;
using System.Threading.Tasks;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserReaderTest

    {
        [Fact]
          public async Task GetUserReaderAsync()
        {


            var reader = new UserReader();
            List<User> usersFromFile = await reader.getUsers();
            User user = usersFromFile [0];



            Assert.Equal("Juan" ,user.Name);
            Assert.Equal("Juan@marmol.com", user.Email);
            Assert.Equal("+5491154762312", user.Phone);
            Assert.Equal("Peru 2464", user.Address);
            Assert.Equal("Normal", user.UserType);
            Assert.Equal(1234, user.Money);



        }



    }
}
