
using Base.Models.Entity.BaseEntity;

namespace Base.Models.Entity
{
    public class VisitResult : AuditableEntity, IBaseEntity<int>
    {
        public int Id { get; set; }
        public int? FacilityId { get; set; }
        public string? ResultType { get; set; }
        public string? Message { get; set; } 
        public string? Note { get; set; } 
        public string? Code { get; set; }
        public Facility? Facility { get; set; }

    }
}
