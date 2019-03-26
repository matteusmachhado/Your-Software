using Microsoft.EntityFrameworkCore;

namespace YS.CMS.Infra.Data
{
    public class CMSRepositoryContext : DbContext
    {
        public CMSRepositoryContext(DbContextOptions<CMSRepositoryContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
