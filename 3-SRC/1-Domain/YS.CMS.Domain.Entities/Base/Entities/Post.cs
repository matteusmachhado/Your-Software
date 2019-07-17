
using System;
using System.Collections.Generic;

namespace YS.CMS.Domain.Base.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; private set; }
        public IList<PostCategory> Categories { get; private set; }
        public Guid Author { get; set; }
        public Guid CreateUser { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? RecycleDate { get; set; }
        public Post(string title, string text )
        {
            this.Id = Guid.NewGuid();
            this.IsActive = true;
            this.CreateDate = DateTime.Now;
            this.Categories = new List<PostCategory>();
            this.Title = title;
            this.Text = text;
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
    }
}
