
using Base.Models.Entity.BaseEntity;

namespace Base.Models.Entity
{
    public class CommunicationChannel:AuditableEntity, IBaseEntity<int>
    {
        public int Id { get; set; }
        public int? FacilityId { get; set; }
        public string? Link { get; set; }
        public int ? ChannelType { get; set; }
        public string? PhoneNumber { get; set; }
        public Facility Facility { get; set;}

    }
}
