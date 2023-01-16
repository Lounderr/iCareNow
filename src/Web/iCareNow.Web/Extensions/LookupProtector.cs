using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace iCareNow.Web.Extensions
{
    public class LookupProtector : ILookupProtector
    {
        public string Protect(string keyId, string data)
        {
            return new string(data?.Reverse().ToArray());
        }

        public string Unprotect(string keyId, string data)
        {
            return new string(data?.Reverse().ToArray());
        }
    }
}
