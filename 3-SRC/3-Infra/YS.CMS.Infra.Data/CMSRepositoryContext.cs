using Microsoft.EntityFrameworkCore;
using YS.CMS.Domain.Base.Entities;
using YS.CMS.Infra.Data.Mapping;

namespace YS.CMS.Infra.Data
{
    public class CMSRepositoryContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<PostCategory> PostCategory { get; set; }

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
            modelBuilder
                .Entity<PostCategory>()
                .HasKey(pc => new { pc.PostId, pc.CategoryId }); // >_ Many to Many with chave composta

            modelBuilder.Entity<PostCategory>()
                .HasOne<Post>(sc => sc.Post)
                .WithMany(s => s.Categories)
                .HasForeignKey(sc => sc.PostId);

            modelBuilder.Entity<PostCategory>()
                .HasOne<Category>(sc => sc.Category)
                .WithMany(s => s.Posts)
                .HasForeignKey(sc => sc.CategoryId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
