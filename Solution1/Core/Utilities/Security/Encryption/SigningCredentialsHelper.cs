
using Microsoft.IdentityModel.Tokens;

namespace Core
{
    public class SigningCredentialsHelper
    {
        //elimdekii keyi byte array haline getirmeye ve onu simetrik keye cevirir
        //credentials sisteme girebilmek için elimizde olanlardır ASPNET İÇİN YAZILMIŞ
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); //anahtar olarak bu securiityKey şifreleem olarak da hmac kullan
        }
    }
}
