using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Common.Interface
{
    public interface IServiceManager
    {
        ISecurityDataProtector SecurityDataProtector { get; }
        ICustomConventer CustomConventer { get; }

    }
}
