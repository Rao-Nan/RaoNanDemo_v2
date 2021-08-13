using demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetUser();
    }
}
