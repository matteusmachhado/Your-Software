using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Domain.Base.Interfaces;

namespace YS.CMS.Infra.Data.Repository
{
    public class PostRepositorio : RepositorioBase<Post>, IPost
    {
        private readonly CMSRepositoryContext _context;

        public PostRepositorio(CMSRepositoryContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Post> FindWithCategories(Guid id)
        {
            return await _context
                .Posts
                .Include(c => c.Categories)
                .ThenInclude(cc => cc.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
