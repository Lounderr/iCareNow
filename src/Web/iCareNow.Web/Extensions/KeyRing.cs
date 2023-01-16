using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace iCareNow.Web.Extensions
{

    public class KeyRing : ILookupProtectorKeyRing
    {
        public string this[string keyId] => "key";

        public string CurrentKeyId => "key";

        public IEnumerable<string> GetAllKeyIds()
        {
            return new string[] { "key" };
        }
    }
}
