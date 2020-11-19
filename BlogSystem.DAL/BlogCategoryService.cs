using BlogSystem.IDAL;
using BlogSystem.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.DAL
{
    public class BlogCategoryService : BaseService<Models.BlogCategory>, IBlogCategory
    {
        public BlogCategoryService() : base(new BlogContext()) 
        {
         
        }
    }
}
