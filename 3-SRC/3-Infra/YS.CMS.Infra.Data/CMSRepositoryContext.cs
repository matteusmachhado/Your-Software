using Microsoft.EntityFrameworkCore;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Infra.Data
{
    public class CMSRepositoryContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
