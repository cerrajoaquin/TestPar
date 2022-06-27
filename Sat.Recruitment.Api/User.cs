using System;
using System.Collections.Generic;

namespace Sat.Recruitment.Api
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }


        public User(string name, string email, string address, string phone, string userType, decimal money)
        {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            UserType = userType;
            Money = money;
         
        }

        public void CalculateGift()
        {

            switch (UserType) {
                case Constants.UserTypeNormal :
            
                if (Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.12);
                    //If new user is normal and has more than USD100
                    var gif = Money * percentage;
                    Money = Money + gif;
                    }
                    else { 
                
                    if (Money > 10)
                    {
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = Money * percentage;
                        Money = Money + gif;
                    }
                  }
                 break;

            case Constants.UserTypeSuperUser:
            
                if (Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.20);
                    var gif = Money * percentage;
                    Money = Money + gif;
                }
            
            break;

            case Constants.UserTypePremium :         
                if (Money > 100)
                {
                    var gif = Money * 2;
                    Money = Money + gif;
                }        
            break;


        }
    }

        public void NormalizeEmail()
        {
            var aux = Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            Email = string.Join("@", new string[] { aux[0], aux[1] });
        }

        public string ValidateErrors()
        {
            List<string> errors = new List<string>();
            if (Name == null)
                //Validate if Name is null
                errors.Add(ErrorMessagesValidateUser.Name);
            if (Email == null)
                //Validate if Email is null
                errors.Add(ErrorMessagesValidateUser.Email);  
            if (Address == null)
                //Validate if Address is null
                errors.Add(ErrorMessagesValidateUser.Address);
            if (Phone == null)
                //Validate if Phone is null
                errors.Add(ErrorMessagesValidateUser.Phone);

            return string.Join(" ", errors);

        }

        public Boolean IsDuplicated(User compared)
        {
            if (Email == compared.Email || Phone == compared.Phone)
            {
               return true;
            }
            else if (Name == compared.Name)
            {
                if (Address == compared.Address)
                {
                   return true;
                }
            }
            return false;
        }
    }
}
