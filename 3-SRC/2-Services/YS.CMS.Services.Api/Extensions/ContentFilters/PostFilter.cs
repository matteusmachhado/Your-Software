using System;
using System.Linq;
using YS.CMS.Common.Utils;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Services.Api.Extensions.ContentFilters
{
    public static class PostFilter
    {
        public static IQueryable<Post> ApplyFilter(this IQueryable<Post> query, PostFilterModel filter)
        {
            if (filter != null)
            {
                if (filter.Title.HasValueNoSpace())
                {
                    query = query.Where(p => p.Title.Contains(filter.Title));
                }
                if (filter.SubTitle.HasValueNoSpace())
                {
                    query = query.Where(p => p.SubTitle.Contains(filter.SubTitle));
                }
                if (filter.IsActive.HasValue)
                {
                    query = query.Where(p => p.IsActive == filter.IsActive);
                }
                if (filter.Category.HasValue)
                {
                    query = query.Where(p => p.Category.Id == filter.Category);
                }
                if (filter.Author.HasValue)
                {
                    query = query.Where(p => p.Author == filter.Author);
                }
                if (filter.CreateUser.HasValue)
                {
                    query = query.Where(p => p.CreateUser == filter.CreateUser);
                }
                if (filter.UpdateUser.HasValue)
                {
                    query = query.Where(p => p.UpdateUser == filter.UpdateUser);
                }
                if (filter.CreateDate.HasValue)
                {
                    query = query.Where(p => p.CreateDate.Date.CompareTo(filter.CreateDate.Value.Date) == 0);
                }
                if (filter.UpdateDate.HasValue)
                {
                    query = query.Where(p => p.UpdateDate.HasValue && p.UpdateDate.Value.Date.CompareTo(filter.UpdateDate.Value.Date) == 0);
                }
                if (filter.PublishDate.HasValue)
                {
                    query = query.Where(p => p.PublishDate.HasValue && p.PublishDate.Value.Date.CompareTo(filter.PublishDate.Value.Date) == 0);
                }
            }
            return query;
        }
        public static IQueryable<Post> ApplyOrder(this IQueryable<Post> query, PostOrderModel order)
        {
            if (order.Field.HasValueNoSpace())
            {
                var property = typeof(Post).GetProperty(order.Field);
                if (order.Desc.HasValue && order.Desc.Value)
                {
                    query = query.OrderByDescending(x => property.GetValue(x, null));
                }
                else
                {
                    query = query.OrderBy(x => property.GetValue(x, null));
                }
            }
            return query;
        }
    }
    public class PostFilterModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool? IsActive { get; set; }
        public Guid? Category { get; set; }
        public Guid? Author { get; set; }
        public Guid? CreateUser { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }
    }
    public class PostOrderModel
    {
        public string Field { get; set; }
        public bool? Desc { get; set; }
    }
}
