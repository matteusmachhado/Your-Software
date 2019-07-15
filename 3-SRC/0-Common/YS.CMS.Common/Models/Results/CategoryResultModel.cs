using System;
using System.Collections.Generic;

namespace YS.CMS.Common.Models.Results
{
    public class CategoryResultModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public IList<PostResultModel> Posts { get; set; }
        public Guid CreateUser { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public CategoryResultModel()
        {
            this.Posts = new List<PostResultModel>();
        }
    }
}
