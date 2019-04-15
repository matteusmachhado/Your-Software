
using System;

namespace YS.CMS.Domain.Base.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Text { get; set; }
        public bool? IsActive { get; set; }
        public Category Category { get; set; }
        public Guid Author { get; set; }
        public Guid CreateUser { get; set; }
        public Guid UpdateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
