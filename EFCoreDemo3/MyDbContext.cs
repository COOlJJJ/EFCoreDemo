using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo3
{
    public class MyDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTag { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //配置连接字符串
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("User id=sa;Password=Aa19970110cdj!;Database=EFDemo3;Server=MD2SA1PC\\SQLEXPRESS;Connect Timeout=50;Max Pool size=200;Min pool Size=5");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //从当前程序集加载配置文件
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);



            //配置多对多
            modelBuilder.Entity<PostTag>()
           .HasKey(t => new { t.PostId, t.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                //配置Post的外键PostId
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                //配置Tag的外键TagId 
                .HasForeignKey(pt => pt.TagId);


        }
    }
}
