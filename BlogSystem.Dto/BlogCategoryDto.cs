using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Dto
{
    public class BlogCategoryDto
    {
        public Guid Id { get; set; }
        [Display(Name = "类名")]
        public string CategoryName { get; set; }
    }
}
