using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo3
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("T_Comments");
            //一对多
            builder.HasOne<Article>(c => c.Article).WithMany(a => a.comments).HasForeignKey(x=>x.ArticleId).IsRequired();
        }
    }
}
