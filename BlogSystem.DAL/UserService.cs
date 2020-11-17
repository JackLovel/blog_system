using BlogSystem.IDAL;
using BlogSystem.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.DAL
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService() : base(new BlogContext()) 
        {
         
        }
    }
}
