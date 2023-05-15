
using Base.Models.Entity.BaseEntity;

namespace Base.Models.Entity
{
    public class DepartmentService : AuditableEntity, IBaseEntity<int>
    {
        public DepartmentService()
        {
            OrderResults = new HashSet<OrderResult>();
        }
        public int Id { get; set; }
        public int DepartmentId { get; set;}
        public string ServiceName { get; set; }
        public Department Department { get; set; }
      public  ICollection<OrderResult> OrderResults { get; set; }
    }
}
