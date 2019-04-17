using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YS.CMS.Domain.Base.Entities;

namespace YS.CMS.Infra.Data.Mapping
{
    internal class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .Property(c => c.Name)
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder
                .Property(c => c.Description)
                .HasColumnType("nvarchar(1000)");

            builder
                .Property(c => c.IsActive)
                .HasColumnType("bit")
                .IsRequired();
            
            builder
                .Property(c => c.CreateUser)
                .IsRequired();

            builder
                .Property(c => c.UpdateUser);

            builder
                .Property(c => c.CreateDate)
                .HasColumnType("DateTime")
                .IsRequired();

            builder
                .Property(c => c.PublishDate)
                .HasColumnType("DateTime");

            builder
                .Property(c => c.DeleteDate)
                .HasColumnType("DateTime");
        }
    }
}
