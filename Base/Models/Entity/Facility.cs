using Base.Models.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models.Entity
{
    public class Facility : AuditableEntity, IBaseEntity<int>
    {
        public Facility() { 
        communicationChannels=new HashSet<CommunicationChannel>();
            OrderResults =new HashSet<OrderResult>();
            VisitResult=new HashSet<VisitResult>();
                }
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? FacilityTypeId { get ; set; }
     //   public string FacilityType { get ; set; }
        //public string? Importance { get; set; }
        public string? FacilityActivity { get; set; }
        public string? TradeName { get; set; }
        public string? SpecialistName { get; set;}
        public string? SpecialistAdjective { get; set;}
        public string? Address { get; set;}
       
        public ICollection<CommunicationChannel> communicationChannels { get; set; }
        public ICollection<VisitResult> VisitResult { get; set; }
        public ICollection<OrderResult> OrderResults { get; set; }
        public Visit Visit { get; set; }
        public User User { get; set; }
        public FacilityType FacilityType { get; set; }



    }
}
