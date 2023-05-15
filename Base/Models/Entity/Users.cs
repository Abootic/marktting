

using Base.Models.Entity.BaseEntity;
using Microsoft.AspNetCore.Identity;
namespace Base.Models.Entity
{
    public class User:IdentityUser ,ISoftDelete
    {
        public User() {
            State = 1;
            Facilities =new HashSet<Facility>();
        }
        public string FullName { get; set; } = null!;
      
        public string UserType { get; set; } = null!;

        public string? Email { get; set; }
        public string? Image { get; set; }

        public string? Others { get; set; }
        public int? State { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? LastModfiedBy { get; set; }
        public DateTime? LastModfiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Facility> Facilities { get; set; }
    }
}
