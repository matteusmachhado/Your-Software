
using System;

namespace YS.CMS.Services.Api.Models
{
    public class PostFilterModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Staus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
