using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Domain.Base.Interfaces
{
    public interface IPost : IRepositorioBase<Post>
    {
        Task<Post> FindWithCategories(Guid id);
    }
}
