using System;
using System.Security.Cryptography;
using System.Text;

namespace Task3
{
    internal class HMACGenerator
    {
        private static string HMAC;
        private static string HMACKey;

        public static void Set_HMAC(string computerTurn)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(HMACKey);
            byte[] computerTurnInBytes = Encoding.UTF8.GetBytes(computerTurn);
            byte[] hashBytes;

            using(var sha = new HMACSHA256(keyBytes))
                hashBytes = sha.ComputeHash(computerTurnInBytes);

            HMAC = BitConverter.ToString(hashBytes).Replace("-", "").ToUpper();
        }

        public static void Set_HMACKey()
        {
            byte[] randomBytes = new byte[16];
            using (RandomNumberGenerator rnd = new RNGCryptoServiceProvider())
                rnd.GetBytes(randomBytes);

            HMACKey = BitConverter.ToString(randomBytes).Replace("-", "").ToUpper();
        }

        public static string Get_HMAC()
        {
            return HMAC;
        }

        public static string Get_HMACKey()
        {
            return HMACKey;
        }
    }
}
