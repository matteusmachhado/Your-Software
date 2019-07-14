
using System;

namespace YS.CMS.Domain.Base.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; private set; }
        public string SubTitle { get; private set; }
        public string Text { get; private set; }
        public bool IsActive { get; private set; }
        public Category Category { get; private set; }
        public Guid Author { get; set; }
        public Guid CreateUser { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? RecycleDate { get; set; }

        public Post()
        {
            this.Id = Guid.NewGuid();
            this.IsActive = true;
            this.CreateDate = DateTime.Now;
        }

        public void SetTitle(string title)
        {
            this.Title = title;
        }

        public void SetActive(bool active) {
            this.IsActive = active;
        }

        public void SetRecycle()
        {
            this.IsActive = false;
            this.RecycleDate = DateTime.Now;
        }
    }
}
