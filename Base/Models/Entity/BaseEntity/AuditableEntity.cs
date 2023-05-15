using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models.Entity.BaseEntity
{
    public  class AuditableEntity: ISoftDelete
    {
        public AuditableEntity()
        {
            IsDeleted = false;
        }
        public int? State { get; set; }
        public string? other { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public string? LastModfiedBy { get; set; }
        public DateTime? LastModfiedAt { get;  set; }
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }



    }
    public interface ISoftDelete
    {
         bool IsDeleted { get; set; }
         string? DeletedBy { get; set; }
         DateTime? DeletedAt { get; set; }
    }
}
