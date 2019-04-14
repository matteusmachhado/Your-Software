using Microsoft.EntityFrameworkCore;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Infra.Data
{
    public class CMSRepositoryContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public CMSRepositoryContext(DbContextOptions<CMSRepositoryContext> dbContext) : base(dbContext)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CMS;User ID=matteusmachhado;Password=123;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
