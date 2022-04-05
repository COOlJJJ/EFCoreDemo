using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCoreDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Scaffold-DbContext 'Data Source=MD2SA1PC\SQLEXPRESS;Initial Catalog=EFDemo2;User id=sa;Password=Aa19970110cdj!' Microsoft.EntityFrameworkCore.SqlServer
            //EF Core 逆向工程 根据数据库表生成实体类后进行操作
            Console.WriteLine("Hello World!");
            using (EFDemo2Context eF = new EFDemo2Context())
            {
                //Person a = new Person { Age = "20", Name = "小陈" };
                //eF.People.Add(a);
                //eF.SaveChanges();
                IQueryable<Person> persons = eF.People.Where(x => x.Name == "小陈");
                string sql = persons.ToQueryString();
                Console.WriteLine("这是"+sql);
            }
        }
    }
}
