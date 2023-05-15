using Base.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Data.EntityConfigs
{
    public class FacilityConfig : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.ToTable("Facilities", "dbo");
            builder.HasKey(x => x.Id).HasName("Pk_Facilities").IsClustered();
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.FacilityTypeId).HasColumnName(@"FacilityTypeId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.FacilityActivity).HasColumnName(@"FacilityActivity").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.TradeName).HasColumnName(@"TradeName").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
           // builder.Property(x => x.Importance).HasColumnName(@"Importance").HasColumnType("nvarchar(255)").IsRequired().HasMaxLength(255);
            builder.Property(x => x.SpecialistName).HasColumnName(@"SpecialistName").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.SpecialistAdjective).HasColumnName(@"SpecialistAdjective").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("nvarchar(450)").IsRequired(false);
            builder.HasOne(a => a.User).WithMany(b => b.Facilities).HasForeignKey(a => a.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Facilities_Users");
            builder.HasOne(a => a.FacilityType).WithMany(b => b.Facilities).HasForeignKey(a => a.FacilityTypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Facilities_FacilityType");



        }
    }
}
