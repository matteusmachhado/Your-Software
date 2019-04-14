using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YS.CMS.Common.Utils.Models.Filters;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Domain.Base.interfaces;

namespace YS.CMS.Infra.Data.Repository
{
    public class PostRepositorio : RepositorioBase<Post>, IPost
    {
        private readonly CMSRepositoryContext _context;

        public PostRepositorio(CMSRepositoryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> FilterAsync(PostFilterModel filter)
        {
            IQueryable<Post> query = All.AsNoTracking();

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query.Where(p => p.Title.Contains(filter.Title));
            }
            else if (!string.IsNullOrEmpty(filter.Description))
            {
                query.Where(p => p.Title.Contains(filter.Description));
            }
            return await query.ToListAsync();
        }
    }
}
