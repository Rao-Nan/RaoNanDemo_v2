using demo.Model;
using demo.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Repository.Repository
{
    public class UserRepository: IUserRepository
    {
        public async Task<User> GetUser() 
        {
            return new User() { Nmae = "nolan" }; 
        }
    }
}
