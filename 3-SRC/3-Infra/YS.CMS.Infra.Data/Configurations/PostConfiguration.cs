using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Infra.Data.Configurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .Property(p => p.Title)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(p => p.SubTitle)
                .HasColumnType("nvarchar(256)");

            builder
                .Property(p => p.Text)
                .HasColumnType("nvarchar(1000)")
                .IsRequired();

            builder
                .Property(p => p.IsActive)
                .HasColumnType("bit")
                .HasDefaultValue(true);

            builder
                 .Property(c => c.Author)
                 .IsRequired();

            builder
                .Property(p => p.CreateUser)
                .IsRequired();

            builder
                .Property(p => p.UpdateUser)
                .IsRequired();
            
            builder
                .Property(p => p.CreateDate)
                .HasColumnType("DateTime")
                .HasDefaultValueSql("getdate()");

            builder
               .Property(p => p.UpdateDate)
               .IsRequired();

            builder
                .Property(p => p.PublishDate)
                .HasColumnType("DateTime");

            builder
                .Property(p => p.DeleteDate)
                .HasColumnType("DateTime");
            
        }
    }
}
