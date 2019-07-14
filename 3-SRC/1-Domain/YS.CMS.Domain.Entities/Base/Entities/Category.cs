using System;
using System.Collections.Generic;

namespace YS.CMS.Domain.Base.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public IList<Post> Posts { get; set; }
        public Guid CreateUser { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public Category()
        {
            this.Id = Guid.NewGuid();
            this.IsActive = true;
            this.CreateDate = DateTime.Now;
        }

    }
}
