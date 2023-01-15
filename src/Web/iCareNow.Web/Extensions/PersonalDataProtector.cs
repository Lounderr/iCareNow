using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace iCareNow.Web.Extensions
{

    public class PersonalDataProtector : IPersonalDataProtector
    {
        public string Protect(string data)
        {
            return new string(data?.Reverse().ToArray());
        }

        public string Unprotect(string data)
        {
            return new string(data?.Reverse().ToArray());
        }
    }
}
