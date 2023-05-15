using Base.Models.Dto;

namespace markettng.ViewModel
{
    public class OrderResultVm
    {
       public IEnumerable<DepartmentDto> departmentVm { get; set; }
       public List<OrderResultDto> orderResultVm { get; set; }
        public DepartmentDto obj { get; set; }

    }
    public class OrderResultVm1
    {
        public List<int>? DepartmentServiceId { get; set; }
        public string? FacilityId { get; set; }
        public string? Note { get; set; }
        public string? other { get; set; }
    }


}
