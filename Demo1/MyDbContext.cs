using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo1
{
    /// <summary>
    /// 约定配置
    /// 1.表名采用DbContext中的对应的DbSet的属性名
    /// 2.数据表列的名字采用实体类属性的名字,列的数据类型采用和实体类属性类型最兼容的类型。
    /// 3.数据表列的可空性取决于对应实体类属性的可空性
    /// 4.名字为Id的属性为主键 如果主键为short int 或者long类型、默认采用自增字段
    /// 主键为guid类型 默认采用Guid生成机制生成主键值
    /// </summary>
    public class MyDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //配置连接字符串
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("User id=sa;Password=Aa19970110cdj!;Database=EFDemo1;Server=MD2SA1PC\\SQLEXPRESS;Connect Timeout=50;Max Pool size=200;Min pool Size=5");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //从当前程序集加载配置文件
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
