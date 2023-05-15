using Base.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Base.Data.DbContext
{
    public interface IApplicationDbContext
    {
        DbSet<CommunicationChannel> CommunicationChannel { get; }
        DbSet<Department> Department { get; }
        DbSet<DepartmentService> DepartmentService { get; }
        DbSet<Facility> Facility { get; }
        DbSet<FacilityType> FacilityType { get; }
        DbSet<OrderResult> OrderResult { get; }
        DbSet<User> User { get; }
        DbSet<Visit> Visit { get; }
        DbSet<VisitResult> VisitResult { get; }
        
       Task<int> SaveChangeAsync(CancellationToken cancellationToken);
    }
}
