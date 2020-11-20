using System;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.MVCSite.Models.ArticleViewModels
{
    public class EditArticleViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public Guid[] CategoryIds { get; set; }
    }
}