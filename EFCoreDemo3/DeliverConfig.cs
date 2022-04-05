using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo3
{
    public class DeliverConfig : IEntityTypeConfiguration<Deliver>
    {
        public void Configure(EntityTypeBuilder<Deliver> builder)
        {
            //一对一  必须有一个显示的Id
            //快递单: 我有一个订单 就有一个快递单 外键是订单id
            builder.HasOne<Order>(x => x.Order).WithOne(x => x.Deliver).HasForeignKey<Deliver>(x => x.OrderId);
        }
    }
}
