using System;
using System.Collections.Generic;

namespace YS.CMS.Common.Models.View
{
    public class PostViewModel
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Text { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public Guid? Author { get; set; }
        public Guid? CreateUser { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
