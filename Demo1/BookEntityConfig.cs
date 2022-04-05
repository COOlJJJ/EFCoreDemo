using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo1
{
    public class BookEntityConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //FluentAPI 配置 可百度
            //配置实体类和数据库表的对应关系
            builder.ToTable("T_Books");
            //配置字段
            builder.Property(b => b.Title).HasMaxLength(20).IsRequired();
            builder.HasIndex(b => b.AuthorName);//加索引
            builder.Property(b => b.AuthorName).HasMaxLength(20);
        }
    }
}
