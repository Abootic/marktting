using Base.Models.Dto;
using System.ComponentModel.DataAnnotations;


namespace markettng.ViewModel
{
    public class FacilityVm
    {
     
        public FacilityDto obj { get; set; }
        
        public List<FacilityData> facilityDatas { get; set; }

    }
    public class FacilityData
    {
        public int Id { get; set; }
        public string FacilityType { get; set; }
        public string? FacilityActivity { get; set; }
        public string? TradeName { get; set; }
        public string? SpecialistName { get; set; }
        public string? SpecialistAdjective { get; set; }
        public string? Address { get; set; }
        public string? FPhoneNumber { get; set; }
         public string? Link { get; set; }
       
        public string? OPhoneNumber { get; set; }
        public string ?OwnerName { get; set; }
      
        public string? Reason { get; set; }
       
        public DateTime VisitTime { get; set; }
       
        public string? ResultType { get; set; }
      
        public string? Message { get; set; }
        public string? Code { get; set; }
        public string? Note { get; set; }
    }
}
