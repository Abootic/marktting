using Base.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Base.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
       
        IUnitOfWork UnitOfWork { get; }
        IUserRepository UserRepository { get; }
        IRolesRepository RolesRepository { get; }
        ICommunicationChannelRepository communicationChannelRepository { get; }
        IDepartmentRepository departmentRepository { get; }
        IDepartmentServiceRepository departmentServiceRepository { get; }
        IFacilityRepository facilityRepository { get; }
        IOrderResultRepository orderResultRepository { get; }
        IVisitRepository VisitRepository { get; }
        IVisitResultRepository VisitResultRepository { get; }
        IFacilityTypeRepository FacilityTypeRepository { get; }

    }
}
