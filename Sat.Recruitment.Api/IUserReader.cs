using System.Threading.Tasks;
using System.Collections.Generic;


namespace Sat.Recruitment.Api
{
    public interface IUserReader
    {
        public  Task<List<User>> getUsers();

    }
}
