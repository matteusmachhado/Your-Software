﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YS.CMS.Infra.Data;

namespace YS.CMS.Infra.Data.Migrations
{
    [DbContext(typeof(CMSRepositoryContext))]
    partial class CMSRepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YS.CMS.Domain.Base.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("DateTime");

                    b.Property<Guid>("CreateUser");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<Guid?>("UpdateUser");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("YS.CMS.Domain.Base.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Author");

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime?>("CreateDate")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<Guid>("CreateUser");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("DateTime");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("DateTime");

                    b.Property<string>("SubTitle")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("DateTime");

                    b.Property<Guid?>("UpdateUser");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("YS.CMS.Domain.Base.Entities.Post", b =>
                {
                    b.HasOne("YS.CMS.Domain.Base.Entities.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
