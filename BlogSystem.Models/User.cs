﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models
{
    public class User : BaseEntity
    {
        [Required,StringLength(40),Column(TypeName = "varchar")]
        public string Email { get; set; }        
        [Required,StringLength(30),Column(TypeName = "varchar")]
        public string Password { get; set; }
        [Required, StringLength(300), Column(TypeName = "varchar")]
        public string ImagePath { get; set; }
        /// <summary>
        /// 粉丝数量
        /// </summary>
        public int FansCount { get; set; }
        /// <summary>
        /// 关注数
        /// </summary>
        public int FocusCount { get; set; }
        /// <summary>
        /// 博客名
        /// </summary>
        public string SiteName { get; set; }
    }
}
