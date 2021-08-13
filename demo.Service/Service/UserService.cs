using demo.Model;
using demo.Repository.IRepository;
using demo.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Service.Service
{

   

    public  class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUser() 
        {
            return await _userRepository.GetUser();
        }
    }
}
