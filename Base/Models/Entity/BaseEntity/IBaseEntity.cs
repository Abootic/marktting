using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Models.Entity.BaseEntity
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
