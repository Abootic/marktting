
using Base.Models.Entity.BaseEntity;

namespace Base.Models.Entity
{
    public class Department : AuditableEntity, IBaseEntity<int>
    {
        public Department() {
            DepartmentServices=new HashSet<DepartmentService>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DepartmentService> DepartmentServices { get; set; }
    }
}
