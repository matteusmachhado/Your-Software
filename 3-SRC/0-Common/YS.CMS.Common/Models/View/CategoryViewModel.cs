using System;
using System.Collections.Generic;

namespace YS.CMS.Common.Models.View
{
    public class CategoryViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PostViewModel> Posts { get; set; }
        public Guid? CreateUser { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
