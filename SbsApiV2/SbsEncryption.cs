using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SbsApiV2
{
    public class SbsEncryption
    {
        /// <summary>
        /// Construct a new Sbs Encryption object with a token and username, which will calculate the encryption key
        /// </summary>
        /// <param name="encryptionKey"></param>
        public SbsEncryption(string token, int keyStrentheningIterations, string username)
        {
            KeyStrengtheningIterations = keyStrentheningIterations;

            // Create the encryption key from a salt + a token and username
            EncryptionKey = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(Salt + token + username));

            byte[] tmpEncKey = new byte[EncryptionKey.Length];
            Array.Copy(EncryptionKey, tmpEncKey, EncryptionKey.Length);
            aesKey = ManagedPbkdf2Provider.DeriveKey(tmpEncKey,
                Encoding.UTF8.GetBytes(Salt),
                KeyDerivationPrf.HMACSHA1,
                KeyStrengtheningIterations,
                32
                );
        }

        private byte[] aesKey;

        /// <summary>
        /// The static salt to use for all crypto ops
        /// </summary>
        public readonly string Salt = "Adfas245766&#N%^BW,.|%^&*";

        /// <summary>
        /// Used for the PBKD2
        /// </summary>
        public int KeyStrengtheningIterations { get; set; }

        /// <summary>
        /// The encryption key to use for encrypting and decrypting payloads
        /// </summary>
        public byte[] EncryptionKey { get; set; }

        /// <summary>
        /// Generate a random initialization vector for the encryption operation
        /// </summary>
        /// <returns></returns>
        private byte[] GenerateIV()
        {
            byte[] iv = new byte[16];
            new Random().NextBytes(iv);
            return iv;
        }

        /// <summary>
        /// Encrypt a payload
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string EncryptString(string input)
        {
            // Create an iv for the aes encryption
            byte[] iv = GenerateIV();

            string encryptedString = Convert.ToBase64String(AesUtilities.AES_Encrypt_CBC(Encoding.UTF8.GetBytes(input), aesKey, iv));

            return Convert.ToBase64String(iv) + encryptedString;
        }

        /// <summary>
        /// Decrypt a payload
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string DecryptString(string input)
        {
            if (input.Length < 24)
                return null; // Invalid length, can't contain the iv payload

            // Get the iv and the payload by substringing the input
            byte[] ivPayload = Convert.FromBase64String(input.Substring(0, 24));
            byte[] encryptedPaylod = Convert.FromBase64String(input.Substring(24));

            string decryptedString = Encoding.UTF8.GetString(AesUtilities.AES_Decrypt_CBC(encryptedPaylod, aesKey, ivPayload));

            return decryptedString;
        }
    }
}
