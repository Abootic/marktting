using Base.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Data.EntityConfigs
{
    public class OrderResultConfig : IEntityTypeConfiguration<OrderResult>
    {
        public void Configure(EntityTypeBuilder<OrderResult> builder)
        {
            builder.ToTable("OrderResults", "dbo");
            builder.HasKey(x => x.Id).HasName("Pk_OrderResults").IsClustered();
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("int").IsRequired().HasDefaultValue(1);

            builder.Property(x => x.Note).HasColumnName(@"Note").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.FacilityId).HasColumnName(@"FacilityId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.DepartmentServiceId).HasColumnName(@"DepartmentServiceId").HasColumnType("int").IsRequired(false);

            builder.HasOne(a => a.Facility).WithMany(b => b.OrderResults).HasForeignKey(b => b.FacilityId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderResults_Facility");
            builder.HasOne(a => a.DepartmentService).WithMany(b => b.OrderResults).HasForeignKey(b => b.DepartmentServiceId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderResults_DepartmentService");


        }
    }
}
