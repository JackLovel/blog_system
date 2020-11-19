using BlogSystem.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSystem.IBLL
{
    public interface IArticleManager
    {
        Task CreateArticle(string title, string content, Guid[] categoryIds, Guid userId);
        Task CreateCategory(string name,Guid userId);
        Task<List<BlogCategoryDto>> GetAllCategories(Guid userId);
        Task<List<ArticleDto>> GetAllArticlesByUserId(Guid userId);
        Task<List<ArticleDto>> GetAllArticlesByEmail(string email);
        Task<List<ArticleDto>> GetAllArticlesByCategoryId(Guid categoryId);
        Task RemoveCategory(string name); 
        Task EditCategory(Guid categoryId,string newCategory);
        Task RemoveArticle(Guid articleId);
        Task EditArticle(Guid articleId, string title, string content, Guid[] categoryIds);
        Task<bool> ExistsArticle(Guid articleId);
        Task<Dto.ArticleDto> GetOneArticleById(Guid articleId);
    }
}
