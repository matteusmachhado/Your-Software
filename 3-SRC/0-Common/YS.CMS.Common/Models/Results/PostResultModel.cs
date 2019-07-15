﻿using System;
using System.Collections.Generic;

namespace YS.CMS.Common.Models.Results
{
    public class PostResultModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; set; }
        public IList<CategoryResultModel> Categories { get; set; }
        public Guid Author { get; set; }
        public Guid CreateUser { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? RecycleDate { get; set; }

        public PostResultModel()
        {
            this.Categories = new List<CategoryResultModel>();
        }
    }
}
