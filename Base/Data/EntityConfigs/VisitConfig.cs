

using Base.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Data.EntityConfigs
{
    public class VisitConfig : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.ToTable("Visits", "dbo");
            builder.HasKey(x => x.Id).HasName("Pk_Visits").IsClustered();
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("int").IsRequired().HasDefaultValue(1);
            builder.Property(x => x.FacilityId).HasColumnName(@"FacilityId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Reason).HasColumnName(@"Reason").HasColumnType("nvarchar(MAX)").IsRequired(false);
            builder.Property(x => x.VisitTime).HasColumnName(@"VisitTime").HasColumnType("datetime2").IsRequired();
            builder.HasOne(x=>x.Facility).WithOne(a=>a.Visit).HasForeignKey<Visit>(b=>b.FacilityId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Visit_Facility");



        }
    }
}
