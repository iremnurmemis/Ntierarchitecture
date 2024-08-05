
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core
{
    public class SecurityKeyHelper
    {
        //appsetingjsonda verilen securitykeyin SecurityKey karsılığını döner
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
