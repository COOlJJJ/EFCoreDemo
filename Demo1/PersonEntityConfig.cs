using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo1
{
    public class PersonEntityConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //配置实体类和数据库表的对应关系
            builder.ToTable("T_Persons");
        }
    }
}
