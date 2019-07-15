using System;

namespace YS.CMS.Domain.Base.Entities
{
    public class PostCategory
    {
        public Guid PostId { get; set; }
        public Guid CategoryId { get; set; }
        public Post Post { get; set; }
        public Category Category { get; set; }
    }
}
