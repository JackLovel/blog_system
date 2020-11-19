using BlogSystem.IDAL;
using BlogSystem.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.DAL
{
    public class ArticleToCategoryService : BaseService<ArticleToCategory>, IArticleToCategoryService
    {
        public ArticleToCategoryService() : base(new BlogContext()) 
        {
         
        }
    }
}
