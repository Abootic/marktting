
using Base.Models.Entity.BaseEntity;
namespace Base.Models.Entity
{
    public class Visit : AuditableEntity, IBaseEntity<int>
    {
        public int Id { get; set; }
        public int? FacilityId { get; set; }
        public string? Reason { get; set; }
        public DateTime VisitTime { get; set; }
        public Facility Facility { get; set; }
    }
}
