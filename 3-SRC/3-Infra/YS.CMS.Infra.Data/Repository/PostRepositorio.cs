using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
