using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api
{
    public class UserReader : IUserReader
    {
        private string PartialFilePath;

        public UserReader()
        {
            PartialFilePath = Constants.PartialFilePath;
        }
        public UserReader(string partialFilePath )
        {
            PartialFilePath = partialFilePath;
        }


        private StreamReader ReadUsersFromFile()
        {
            var path = Directory.GetCurrentDirectory() + PartialFilePath;

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        public async Task<List<User>> getUsers()
        {
            List<User> ListUsers = new List<User>();
            var reader = ReadUsersFromFile();
            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User(
                     line.Split(',')[0].ToString(),
                     line.Split(',')[1].ToString(),
                     line.Split(',')[3].ToString(),
                     line.Split(',')[2].ToString(),
                     line.Split(',')[4].ToString(),
                     decimal.Parse(line.Split(',')[5].ToString())
                  );
                ListUsers.Add(user);
            }
            reader.Close();

            return ListUsers;
        }

    }
}
