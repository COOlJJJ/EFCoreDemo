using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace EFCoreDemo2
{
    public partial class EFDemo2Context : DbContext
    {
        /// <summary>
        /// 将EF转换的SQL显示 
        /// 1.标准日志 安装Microsoft.Extensions.Logging.Console包
        ///  private static ILoggerFactory loggerFactory = LoggerFactory.Create(b => b.AddConsole());
        ///  optionsBuilder.UseLoggerFactory(loggerFactory);
        ///  用上面两行代码
        ///  2.简单日志
        ///   optionsBuilder.LogTo(msg =>
        //{
        //    Console.WriteLine(msg);
        //});
        /// 3.使用ToQueryString
        /// IQueryable<Person> persons = eF.People.Where(x => x.Name == "小陈");
        //  string sql = persons.ToQueryString();
        //  Console.WriteLine("这是"+sql);
        /// </summary>
        private static ILoggerFactory loggerFactory = LoggerFactory.Create(b => b.AddConsole());
        public EFDemo2Context()
        {
        }

        public EFDemo2Context(DbContextOptions<EFDemo2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MD2SA1PC\\SQLEXPRESS;Initial Catalog=EFDemo2;User id=sa;Password=Aa19970110cdj!");
                //optionsBuilder.UseLoggerFactory(loggerFactory);
                optionsBuilder.LogTo(msg =>
                {
                    Console.WriteLine(msg);
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Age)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("Phone");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Price)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
