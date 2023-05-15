using System.ComponentModel.DataAnnotations;

namespace Base.Models.Dto.BaseDto
{
    public class CommonDto
    {
       public int? Id { get; set; }
        public int? State { get; set; } =1;
        public string CreatedBy { get; set; }

    }
}
