using Base.Common.Classes;
using Base.Common.Interface;
using Base.Data.DbContext;
using Base.Identity;

using Base.Models.Entity;
using Base.Repositories.Implementations;
using Base.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Base.Extensions
{
    public static class AddPresistenceExtensision
    {
        public static IServiceCollection AddPresistence(this IServiceCollection service, IConfiguration configuration)
        {
          service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
           // service.AddAutoMapper(ex => { ex.AddExpressionMapping(); }, AppDomain.CurrentDomain.Load("Base"));
            service.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("SqlServerDB")));

            service.AddIdentity<User, IdentityRole>(bulder =>
            {
                bulder.User.RequireUniqueEmail = false;
                bulder.Password.RequireLowercase = false;
                bulder.Password.RequireDigit = false;
                bulder.Password.RequiredUniqueChars = 0;
                bulder.Password.RequireUppercase = false;
                bulder.Password.RequireNonAlphanumeric = false;
                bulder.Password.RequiredLength = 6;

                
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();
         
          
            ///////////////Facade Pattern regstration
            service.AddScoped<IRepositoryManager, RepositoryManager>();
         
            
            service.AddScoped<IServiceManager, ServiceManager>();
            ////////////////////////////////////////////////////////////////
            service.AddScoped<ISigninManager, SigninManger>();
            //tokenstorage 
         
            //roles and user Repositories
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IRolesRepository, RolesRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<ICustomConventer, CustomConventer>();
        
            service.AddScoped<ICommunicationChannelRepository, CommunicationChannelRepository>();
            service.AddScoped<IDepartmentRepository, DepartmentRepository>();
            service.AddScoped<IDepartmentServiceRepository, DepartmentServiceRepository>();
            service.AddScoped<IFacilityRepository, FacilityRepository>();
            service.AddScoped<IOrderResultRepository, OrderResultRepository>();
            service.AddScoped<IVisitRepository, VisitRepository>();
            service.AddScoped<IVisitResultRepository, VisitResultRepository>();
            service.AddScoped<IFacilityTypeRepository, FacilityTypeRepository>();

            //roles and user LazyRepositories
            // security
            service.AddSingleton<ISecurityDataProtector, SecurityDataProtector>();
            service.AddScoped(provider => new Lazy<IUserRepository>(provider.GetService<IUserRepository>()));
            service.AddScoped(provider => new Lazy<IRolesRepository>(provider.GetService<IRolesRepository>()));
            service.AddScoped(provider => new Lazy<IUnitOfWork>(provider.GetService<IUnitOfWork>()));
            service.AddScoped(provider => new Lazy<ICommunicationChannelRepository>(provider.GetService<ICommunicationChannelRepository>()));
            service.AddScoped(provider => new Lazy<IDepartmentRepository>(provider.GetService<IDepartmentRepository>()));
            service.AddScoped(provider => new Lazy<IDepartmentServiceRepository>(provider.GetService<IDepartmentServiceRepository>()));
            service.AddScoped(provider => new Lazy<IFacilityRepository>(provider.GetService<IFacilityRepository>()));
            service.AddScoped(provider => new Lazy<IOrderResultRepository>(provider.GetService<IOrderResultRepository>()));
            service.AddScoped(provider => new Lazy<IVisitRepository>(provider.GetService<IVisitRepository>()));
            service.AddScoped(provider => new Lazy<IVisitResultRepository>(provider.GetService<IVisitResultRepository>()));
            service.AddScoped(provider => new Lazy<IFacilityTypeRepository>(provider.GetService<IFacilityTypeRepository>()));
            service.AddScoped(provider => new Lazy<ISecurityDataProtector>(provider.GetService<ISecurityDataProtector>()));
            service.AddScoped(provider => new Lazy<ICustomConventer>(provider.GetService<ICustomConventer>()));
            return service;
        }

    }
}
