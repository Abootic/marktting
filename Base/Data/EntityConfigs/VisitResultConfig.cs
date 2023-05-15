

using Base.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Data.EntityConfigs
{
    public class VisitResultConfig : IEntityTypeConfiguration<VisitResult>
    {
        public void Configure(EntityTypeBuilder<VisitResult> builder)
        {
            builder.ToTable("VisitResults", "dbo");
            builder.HasKey(x => x.Id).HasName("Pk_VisitResult").IsClustered();
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.State).HasColumnName(@"State").HasColumnType("int").IsRequired().HasDefaultValue(1);
            builder.Property(x => x.ResultType).HasColumnName(@"ResultType").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.Code).HasColumnName(@"Code").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.Message).HasColumnName(@"Message").HasColumnType("nvarchar(MAX)").IsRequired(false);
            builder.Property(x => x.Note).HasColumnName(@"Note").HasColumnType("nvarchar(MAX)").IsRequired(false);

            builder.Property(x => x.FacilityId).HasColumnName(@"FacilityId").HasColumnType("int").IsRequired();
            builder.HasOne(a => a.Facility).WithMany(b => b.VisitResult).HasForeignKey(b => b.FacilityId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_VisitResult_Facility");


        }
    }
}
