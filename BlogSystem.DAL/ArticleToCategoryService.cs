using BlogSystem.IDAL;
using BlogSystem.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystem.DAL
{
    public class ArticleToCategoryService : BaseService<ArticleToCategory>, IArticleToCategory
    {
        public ArticleToCategoryService() : base(new BlogContext()) 
        {
         
        }
    }
}
