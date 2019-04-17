using Microsoft.EntityFrameworkCore;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Infra.Data.Mapping;

namespace YS.CMS.Infra.Data
{
    public class CMSRepositoryContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CMSRepositoryContext(DbContextOptions<CMSRepositoryContext> dbContext) : base(dbContext)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Post>(new PostMap());
            modelBuilder.ApplyConfiguration<Category>(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
