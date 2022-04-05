using System;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1
{
    class Program
    {
        /// <summary>
        /// 开发环境搭建(Nuget EFCore、EFCore.Tools、EFCore.Sqlserver)
        /// 1.建实体类
        /// 2.建DbContext
        /// 补充概念Migration
        /// Migration工具生成数据库、关系数据库是存放模型数据的一个媒介
        /// 根据对象的定义变化，自动更新数据库中的表以及表结构的操作叫做Migration.
        /// Add-Migration Name  Name方便回滚 添加迁移版本
        /// Update-Database  XXX执行迁移
        /// 把数据库回滚到XXX的状态 迁移脚本不动
        /// Remove-migration
        /// 删除最后一次的迁移脚本
        /// Script-Migration
        /// 生成迁移SQL代码
        /// Script-Migration D F
        /// 生成D到F版本的SQL代码
        /// 
        /// </summary>
        /// <param name="args"></param>
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //CRUD

            using (MyDbContext myDbContext = new MyDbContext())
            {
                ////插入
                //Person p = new Person
                //{
                //    Age = 20,
                //    Name = "小陈",
                //    BirthPlace = "无锡",
                //};
                //await myDbContext.Persons.AddAsync(p);
                //await myDbContext.SaveChangesAsync();

                //LinQ 查询
                //Person person = myDbContext.Persons.Where(b => b.BirthPlace == "无锡").FirstOrDefault();
                //Console.WriteLine(person.Name);

                //修改和删除 查出来的数据在操作
                //Person person = myDbContext.Persons.Where(b => b.BirthPlace == "江阴").FirstOrDefault();
                //person.BirthPlace = "无锡";
                //myDbContext.Remove(person);
                //await myDbContext.SaveChangesAsync();
                
            }


        }
    }
}