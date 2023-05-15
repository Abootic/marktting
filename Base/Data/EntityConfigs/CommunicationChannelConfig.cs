using Base.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.EntityConfigs
{
    public class CommunicationChannelConfig : IEntityTypeConfiguration<CommunicationChannel>
    {
        public void Configure(EntityTypeBuilder<CommunicationChannel> builder)
        {
            builder.ToTable("CommunicationChannels", "dbo");
            builder.HasKey(x => x.Id).HasName("Pk_CommunicationChannels").IsClustered();
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Link).HasColumnName(@"Link").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.ChannelType).HasColumnName(@"ChannelType").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.PhoneNumber).HasColumnName(@"PhoneNumber").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("int").IsRequired().HasDefaultValue(1);

            builder.Property(x => x.FacilityId).HasColumnName(@"FacilityId").HasColumnType("int").IsRequired(false);
            builder.HasOne(a => a.Facility).WithMany(b => b.communicationChannels).HasForeignKey(b => b.FacilityId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CommunicationChannel_Facility");


        }
    }
}
