using System;
using System.Security.Cryptography;

namespace ElectionVote.Services.Cryptography {
    public class PBKDF2 {

        public static byte[] GenerateSalt() {
            using (var randomNumGenerator = new RNGCryptoServiceProvider()) {
                var randomNumber = new byte[32];
                randomNumGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        public static byte[] HashPassword(byte[] toBeHashed, byte[] salt, int numberOfRounds) {
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, HashAlgorithmName.SHA256)) {
                return rfc2898.GetBytes(20);
            }
        }

    }
}
