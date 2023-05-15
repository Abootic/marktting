

using Base.Common.Interface;
using Base.Repositories.Interfaces;

namespace Base.Repositories.Implementations
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly Lazy<IUnitOfWork> _LazyIUnitOfWork;
        //  //roles and user Repositories
        private readonly Lazy<IUserRepository> _LazyUserRepository;
        private readonly Lazy<IRolesRepository> _LazyRolesRepository;
        private readonly Lazy<ICommunicationChannelRepository> _LazyCommunicationChannelRepository;
        private readonly Lazy<IDepartmentRepository> _LazydepartmentRepository;
        private readonly Lazy<IDepartmentServiceRepository> _LazydepartmentServiceRepository;
        private readonly Lazy<IFacilityRepository> _LazyFacilityRepository;
        private readonly Lazy<IOrderResultRepository> _LazyOrderResultRepository;
        private readonly Lazy<IVisitRepository> _LazyVisitRepository;
        private readonly Lazy<IVisitResultRepository> _LazyVisitResultRepository;
        private readonly Lazy<IFacilityTypeRepository> _LazyFacilityTypeRepository;

        public RepositoryManager(Lazy<IUnitOfWork> lazyIUnitOfWork, Lazy<IUserRepository> lazyUserRepository, Lazy<IRolesRepository> lazyRolesRepository, Lazy<ICommunicationChannelRepository> lazyCommunicationChannelRepository, Lazy<IDepartmentRepository> lazydepartmentRepository, Lazy<IDepartmentServiceRepository> lazydepartmentServiceRepository, Lazy<IFacilityRepository> lazyFacilityRepository, Lazy<IOrderResultRepository> lazyOrderResultRepository, Lazy<IVisitRepository> lazyVisitRepository, Lazy<IVisitResultRepository> lazyVisitResultRepository, Lazy<IFacilityTypeRepository> lazyFacilityTypeRepository)
        {
            _LazyIUnitOfWork = lazyIUnitOfWork;
            _LazyUserRepository = lazyUserRepository;
            _LazyRolesRepository = lazyRolesRepository;
            _LazyCommunicationChannelRepository = lazyCommunicationChannelRepository;
            _LazydepartmentRepository = lazydepartmentRepository;
            _LazydepartmentServiceRepository = lazydepartmentServiceRepository;
            _LazyFacilityRepository = lazyFacilityRepository;
            _LazyOrderResultRepository = lazyOrderResultRepository;
            _LazyVisitRepository = lazyVisitRepository;
            _LazyVisitResultRepository = lazyVisitResultRepository;
            _LazyFacilityTypeRepository = lazyFacilityTypeRepository;
        }

        //public RepositoryManager(Lazy<IUnitOfWork> lazyIUnitOfWork, Lazy<IUserRepository> lazyUserRepository, Lazy<IRolesRepository> lazyRolesRepository, Lazy<ICommunicationChannelRepository> lazyCommunicationChannelRepository, Lazy<IDepartmentRepository> lazydepartmentRepository, Lazy<IDepartmentServiceRepository> lazydepartmentServiceRepository, Lazy<IFacilityRepository> lazyFacilityRepository, Lazy<IOrderResultRepository> lazyOrderResultRepository, Lazy<IVisitRepository> lazyVisitRepository, Lazy<IVisitResultRepository> lazyVisitResultRepository)
        //{
        //    _LazyIUnitOfWork = lazyIUnitOfWork;
        //    _LazyUserRepository = lazyUserRepository;
        //    _LazyRolesRepository = lazyRolesRepository;
        //    _LazyCommunicationChannelRepository = lazyCommunicationChannelRepository;
        //    _LazydepartmentRepository = lazydepartmentRepository;
        //    _LazydepartmentServiceRepository = lazydepartmentServiceRepository;
        //    _LazyFacilityRepository = lazyFacilityRepository;
        //    _LazyOrderResultRepository = lazyOrderResultRepository;
        //    _LazyVisitRepository = lazyVisitRepository;
        //    _LazyVisitResultRepository = lazyVisitResultRepository;
        //}

        public IUnitOfWork UnitOfWork => _LazyIUnitOfWork.Value;
       
        public IUserRepository UserRepository => _LazyUserRepository.Value;
        public IRolesRepository RolesRepository => _LazyRolesRepository.Value;

        public ICommunicationChannelRepository communicationChannelRepository => _LazyCommunicationChannelRepository.Value;

        public IDepartmentRepository departmentRepository => _LazydepartmentRepository.Value;

        public IDepartmentServiceRepository departmentServiceRepository =>_LazydepartmentServiceRepository.Value;

        public IFacilityRepository facilityRepository => _LazyFacilityRepository.Value;

        public IOrderResultRepository orderResultRepository => _LazyOrderResultRepository.Value;

        public IVisitRepository VisitRepository => _LazyVisitRepository.Value;

        public IVisitResultRepository VisitResultRepository => _LazyVisitResultRepository.Value;
        public IFacilityTypeRepository FacilityTypeRepository => _LazyFacilityTypeRepository.Value;
    }
}
