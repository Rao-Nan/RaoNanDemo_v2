using demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Service.IService
{
    public interface IUserService
    {
        Task<User> GetUser();
    }
}
