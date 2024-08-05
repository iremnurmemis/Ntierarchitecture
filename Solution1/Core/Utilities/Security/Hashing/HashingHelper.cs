

using System.Security.AccessControl;
using System.Text;

namespace Core
{
    public class HashingHelper
    {
        //verdiğimiz passwordun hashini olusturur database eklerken mesela
        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt) //dısarıya out verilerini verir
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //kullanılan algoritmanın keyi dir her kullanıcı için farklıdır
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //sonradan sisteme girerken girilen passwordu veri kaynağımızdaki hashle(ilgili salta göre) eşleşip eşleşmediğine bakar
        public static bool VerifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) //doğrulamayı passwordsalta göre yapıcak
            {
                 var computedHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
