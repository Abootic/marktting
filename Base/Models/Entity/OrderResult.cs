using Base.Models.Entity.BaseEntity;

namespace Base.Models.Entity
{
    public class OrderResult : AuditableEntity, IBaseEntity<int>
    {
        public int Id { get; set; }
        public int?DepartmentServiceId { get; set; }
        public int? FacilityId { get; set; }
        public string? Note { get ; set; }
        public Facility Facility { get; set;}
        public DepartmentService DepartmentService { get; set; }

    }
}
