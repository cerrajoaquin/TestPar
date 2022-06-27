namespace Sat.Recruitment.Api
{
    public class Constants
    {
        public const string UserTypeNormal = "Normal";
        public const string UserTypeSuperUser = "SuperUser";
        public const string UserTypePremium = "Premium";
        public const string PartialFilePath = "/Files/Users.txt";

    }

    public class Messages
    {
        public const string DuplicatedUser = "The user is duplicated";
        public const string UserCreated = "User Created";
    }
    public class ErrorMessagesValidateUser
    {
        public const string Name = "The name is required";
        public const string Email = "The email is required";
        public const string Address = "The address is required";
        public const string Phone = "The phone is required";

    }
}
