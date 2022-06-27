using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api;


using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]

    public class UserTests
    {

        //Email Test
        [Fact]
        public void NormalizeEmailNormal()
        {

            var user = new User("juan", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse( "124"));

            user.NormalizeEmail();

            Assert.Equal("mike@gmail.com", user.Email );
        }

        [Fact]
        public void NormalizeEmailSpace()
        {

            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("124"));

            user.NormalizeEmail();

            Assert.Equal("mike@gmail.com", user.Email);
        }

        //Money Test
         // Premium
        [Fact]
        public void UserTypePremiumMoreHundred()
        {

            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Premium", decimal.Parse("124"));

            user.CalculateGift();

            Assert.Equal(372, user.Money);
        }
        [Fact]
        public void UserTypePremiumLessHundred()
        {

            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Premium", decimal.Parse("99"));

            user.CalculateGift();

            Assert.Equal(99, user.Money);
        }
        // SuperUser
        [Fact]
        public void UserTypeSuperUserMoreHundred()
        {

            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "SuperUser", decimal.Parse("200"));

            user.CalculateGift();

            Assert.Equal(decimal.Parse("240.0"), user.Money);
        }
        [Fact]
        public void UserTypeSuperUserLessHundred()
        {

            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "SuperUser", decimal.Parse("99"));

            user.CalculateGift();

            Assert.Equal(99, user.Money);
        }
        // normal
        [Fact]
        public void UserTypeNormalLessTen()
        {

            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("10"));

            user.CalculateGift();

            Assert.Equal(10, user.Money);
        }
        [Fact]
        public void UserTypeNormalMoreTen()
        {

            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("11"));

            user.CalculateGift();

            Assert.Equal(decimal.Parse("19.8"), user.Money);
        }
        [Fact]
        public void UserTypeNormalMoreHundred()
        {

            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("101"));

            user.CalculateGift();

            Assert.Equal(decimal.Parse("113.12"), user.Money);
        }
        //Isduplicated Test
        [Fact]
        public void IsDuplicatedSucess()
        {
            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("101"));
            var user2 = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("101"));
            Assert.True(user.IsDuplicated(user2));
        }
        [Fact]
        public void IsDuplicatedFailure()
        {
            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("101"));
            var user2 = new User("juana", "am.ike@gmail.com", "Av. Juan Ga", "+349 11223542156", "Normal", decimal.Parse("101"));
            Assert.False(user.IsDuplicated(user2));
        }


        [Fact]
        public void IsDuplicatedEmail()
        {
            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("101"));
            var user2 = new User("juana", "m.ike@gmail.com", "Av. Juan Ga", "+349 11223542156", "Normal", decimal.Parse("101"));
            Assert.True(user.IsDuplicated(user2));
        }


        [Fact]
       public void IsDuplicatedPhone()
        {
            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("101"));
            var user2 = new User("juana", "m.ike@gmail.com", "Av. Juan Ga", "+349 1122354215", "Normal", decimal.Parse("101"));
            Assert.True(user.IsDuplicated(user2));
        }
        [Fact]
        public void IsDuplicatedName()
        {
            var user = new User("juan", "m.ike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("101"));
            var user2 = new User("juan", "am.ike@gmail.com", "Av. Juan G", "+349 11223542156", "Normal", decimal.Parse("101"));
            Assert.True(user.IsDuplicated(user2));
        }

    }
}
