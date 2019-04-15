using Microsoft.EntityFrameworkCore;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Infra.Data.Configurations;

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
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CMS;User ID=matteusmachhado;Password=123;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Post>(new PostConfiguration());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
