
using System;

namespace YS.CMS.Domain.Base.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; private set; }
        public string SubTitle { get; private set; }
        public string Text { get; private set; }
        public bool Active { get; private set; }
        public Category Category { get; private set; }
        public Guid Author { get; private set; }
        public Guid CreateUser { get; private set; }
        public Guid? UpdateUser { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public DateTime? PublishDate { get; private set; }
        public DateTime? DeleteDate { get; private set; }

        public Post()
        {
            this.Active = true;
            this.CreateDate = DateTime.Now;
        }

        public void SetTitle(string title)
        {
            this.Title = title;
        }

        public void SetActive(bool active) {
            this.Active = active;
        }
    }
}
