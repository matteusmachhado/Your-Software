﻿using System;
using System.Collections.Generic;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Services.Api.Models
{
    public class PostFilterModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Text { get; set; }
        public bool? IsActive { get; set; }
        public List<Category> Category { get; set; }
        public Guid Author { get; set; }
        public Guid CreateUser { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
