
using Base.Common.Interface;
using Base.Data.EntityConfigs;
using Base.Models.Entity;
using Base.Models.Entity.BaseEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Base.Data.DbContext
{
    public partial class ApplicationDbContext: IdentityDbContext<User>, IApplicationDbContext
    {
        private readonly ICurrentUserServices _currentUserServices;
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserServices currentUserServices) : base(options)
        {
            _currentUserServices = currentUserServices;
        }

        public DbSet<CommunicationChannel> CommunicationChannel { get;private set; }

        public DbSet<Department> Department { get; private set; }

        public DbSet<DepartmentService> DepartmentService { get; private set; }

        public DbSet<Facility> Facility { get;private set; }
        public DbSet<FacilityType> FacilityType { get;private set; }

    public DbSet<OrderResult> OrderResult { get; private set; }

        public DbSet<User> User { get; private set; }

        public DbSet<Visit> Visit { get; private set; }

        public DbSet<VisitResult> VisitResult { get;private set; }

  

    public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken())
    {
            try
            {

                foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
                {

                    switch (entry.State)
                    {

                        case EntityState.Added:
                            //entry.Entity.CreatedBy = "wejo";
                            entry.Entity.CreatedBy = _currentUserServices.UserName;
                            entry.Entity.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            entry.Entity.LastModfiedBy = _currentUserServices.UserName;
                            entry.Entity.LastModfiedAt = DateTime.UtcNow;

                            break;
                        case EntityState.Deleted:
                            entry.Entity.DeletedBy = _currentUserServices.UserName;
                            entry.Entity.DeletedAt = DateTime.UtcNow;
                            entry.Entity.IsDeleted = true;
                            break;
                    }

                }
               
            }catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.ApplyConfiguration(new CommunicationChannelConfig());
        modelBuilder.ApplyConfiguration(new DepartmentConfig());
        modelBuilder.ApplyConfiguration(new DepartmentServiceConfig());
        modelBuilder.ApplyConfiguration(new FacilityConfig());

        modelBuilder.ApplyConfiguration(new OrderResultConfig());
        modelBuilder.ApplyConfiguration(new VisitConfig());
        modelBuilder.ApplyConfiguration(new VisitResultConfig());
        modelBuilder.ApplyConfiguration(new FacilityTypeConfig());
    

        OnModelCreatingPartial(modelBuilder);



    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}
