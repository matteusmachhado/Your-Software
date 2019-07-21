
using System;
using System.Collections.Generic;

namespace YS.CMS.Domain.Base.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; private set; }
        public string SubTitle { get; private set; }
        public string Text { get; private set; }
        public bool IsActive { get; private set; }
        public IList<PostCategory> Categories { get; private set; }
        public Guid Author { get; private set; }
        public Guid CreateUser { get; private set; }
        public Guid? UpdateUser { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public DateTime? PublishDate { get; private set; }
        public DateTime? DeleteDate { get; private set; }
        public DateTime? RecycleDate { get; private set; }
        public Post(string title, string text)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Text = text;
            this.IsActive = true;
            this.CreateDate = DateTime.Now;
            this.Categories = new List<PostCategory>();
        }
        public void SetTitle(string title)
        {
            this.Title = title;
        }
        public void SetText(string text)
        {
            this.Text = text;
        }
        public void SetActive(bool active) {
            this.IsActive = active;
        }
        public void SetRecycle()
        {
            this.IsActive = false;
            this.RecycleDate = DateTime.Now;
        }
        public void AddRangeCategory(params Category[] categories)
        {
            foreach (var category in categories)
            {
                this.Categories.Add(new PostCategory() { Category = category });
            }
        }
        public void RemoveRengeCategory(params Category[] categories)
        {
            foreach (var category in categories)
            {
                this.Categories.Remove(new PostCategory() { Category = category });
            }
        }
        public void RemoveAllCategories()
        {
            this.Categories.Clear();
        }
        public void SetCreateUser(Guid userGuid)
        {
            this.CreateUser = userGuid;
        }
    }
}
