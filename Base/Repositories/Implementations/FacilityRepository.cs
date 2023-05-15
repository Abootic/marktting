using Base.Data.DbContext;
using Base.Models.Entity;
using Base.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repositories.Implementations
{
    public class FacilityRepository : GenirecRopoistories<Facility>, IFacilityRepository
    {
        public FacilityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
