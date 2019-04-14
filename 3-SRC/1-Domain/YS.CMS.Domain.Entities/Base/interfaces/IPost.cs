using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YS.CMS.Common.Utils.Models.Filters;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Domain.Base.interfaces
{
    public interface IPost : IRepositorioBase<Post>
    {
        Task<IEnumerable<Post>> FilterAsync(PostFilterModel filter);
    }
}
