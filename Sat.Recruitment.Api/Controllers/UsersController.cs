using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using System.IO;

namespace Sat.Recruitment.Api.Controllers
{
 

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {

        private readonly IUserReader _reader;
        public UsersController(IUserReader reader)
        {
            _reader = reader;
        }
    

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            try
            {

                var newUser = new User(name, email, address, phone, userType, decimal.Parse(money));

                var errors = newUser.ValidateErrors();

                if (errors != null && errors != "")
                    return new Result()
                    {
                        IsSuccess = false,
                        Errors = errors
                    };
                newUser.CalculateGift();
                newUser.NormalizeEmail();


                //var reader = new UserReader();
                List<User> _users = await _reader.getUsers();

                foreach (var user in _users)
                {
                    if (newUser.IsDuplicated(user))
                    {
                        Debug.WriteLine(Messages.DuplicatedUser);
                        return new Result()
                        {
                            IsSuccess = false,
                            Errors = Messages.DuplicatedUser
                        };
                    }
                }

                Debug.WriteLine(Messages.UserCreated);
                return new Result()
                {
                    IsSuccess = true,
                    Errors = Messages.UserCreated
                };
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return new Result()
                {
                    IsSuccess = false,
                    Errors = e.Message 
                };
            }


        }
       
    }
   
}
