using Base.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Data.EntityConfigs
{
    public class DepartmentServiceConfig : IEntityTypeConfiguration<DepartmentService>
    {
        public void Configure(EntityTypeBuilder<DepartmentService> builder)
        {
            builder.ToTable("DepartmentServices", "dbo");
            builder.HasKey(x => x.Id).HasName("Pk_DepartmentServices").IsClustered();
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.ServiceName).HasColumnName(@"ServiceName").HasColumnType("nvarchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(x => x.DepartmentId).HasColumnName(@"DepartmentId").HasColumnType("int").IsRequired();
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("int").IsRequired().HasDefaultValue(1);

            builder.HasOne(a => a.Department).WithMany(b => b.DepartmentServices).HasForeignKey(b => b.DepartmentId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_DepartmentServices_Department");

        }
    }
}
