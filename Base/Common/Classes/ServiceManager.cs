using Base.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Common.Classes
{
    public class ServiceManager: IServiceManager
    {
        private readonly Lazy<ISecurityDataProtector> _LazySecurityDataProtector;
        private readonly Lazy<ICustomConventer> _LazyCustomConventer;

        public ServiceManager(Lazy<ISecurityDataProtector> lazySecurityDataProtector, Lazy<ICustomConventer> lazyCustomConventer)
        {
            _LazySecurityDataProtector = lazySecurityDataProtector;
            _LazyCustomConventer = lazyCustomConventer;
        }

        public ISecurityDataProtector SecurityDataProtector => _LazySecurityDataProtector.Value;

        public ICustomConventer CustomConventer => _LazyCustomConventer.Value;
    }
}
