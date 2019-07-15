using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Domain.Base.Interfaces;

namespace YS.CMS.Infra.Data.Repository
{
    public class CategoryRepository : RepositorioBase<Category>, ICategory
    {
        private readonly CMSRepositoryContext _context;

        public CategoryRepository(CMSRepositoryContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
