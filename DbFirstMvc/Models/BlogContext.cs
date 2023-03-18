using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbFirstMvc.Models
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=ASPOSE\\SQLEXPRESS01;Database=Blog;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .HasColumnName("author")
                    .IsFixedLength();

                entity.Property(e => e.Createdon)
                    .HasColumnType("datetime")
                    .HasColumnName("createdon");

                entity.Property(e => e.Text).HasColumnName("text");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Articleid).HasColumnName("articleid");

                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .HasColumnName("author")
                    .IsFixedLength();

                entity.Property(e => e.Createdon)
                    .HasColumnType("datetime")
                    .HasColumnName("createdon");

                entity.Property(e => e.Text)
                    .HasMaxLength(300)
                    .HasColumnName("text");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Articleid)
                    .HasConstraintName("FK_Comment_Article");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
