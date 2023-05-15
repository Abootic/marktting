using Base.Models.Entity.BaseEntity;
namespace Base.Models.Entity
{
    public class FacilityType:AuditableEntity, IBaseEntity<int>
    {
        public FacilityType()
        {
            Facilities = new HashSet<Facility>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Facility> Facilities { get; set; }
    }
}
