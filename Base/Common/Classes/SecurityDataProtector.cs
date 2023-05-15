using Base.Common.Interface;
using Microsoft.AspNetCore.DataProtection;

namespace Base.Common.Classes
{
    public class SecurityDataProtector : ISecurityDataProtector
    {
        private readonly IDataProtector DataProtector;

       

        public SecurityDataProtector(Microsoft.AspNetCore.DataProtection.IDataProtectionProvider dataProtectionProvider)
        {
            this.DataProtector = dataProtectionProvider.CreateProtector("Query");

        }
      public  string Decode(string value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value)) return value;
                return this.DataProtector.Unprotect(value);
            }catch (Exception ex)
            {
                return value;
            }
        }

        public string Encode(string value)
        {
            try {
                if (string.IsNullOrWhiteSpace(value)) return value;
                return this.DataProtector.Protect(value);
            } catch (Exception ex) { return value; }
        }
       
    }
}
