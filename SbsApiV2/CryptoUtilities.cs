using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SbsApiV2
{
    /// <summary>
    /// Simple cryptography utilities, mainly wrapping inbuilt crypto functions
    /// </summary>
    public static class CryptoUtilities
    {
        /// <summary>
        /// Encrypt a byte array using AES in CBC mode
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <param name="initVector"></param>
        /// <returns></returns>
        public static byte[] AES_Encrypt_CBC(byte[] input, byte[] key, byte[] initVector)
        {
            using (var aes = Aes.Create())
            {
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.Key = key;
                aes.IV = initVector;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var resultStream = new MemoryStream())
                {
                    using (var aesStream = new CryptoStream(resultStream, encryptor, CryptoStreamMode.Write))
                    using (var plainStream = new MemoryStream(input))
                    {
                        plainStream.CopyTo(aesStream);
                    }

                    return resultStream.ToArray();
                }
            }
        }

        /// <summary>
        /// Decrypt a byte array using AES in CBC mode
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <param name="initVector"></param>
        /// <returns></returns>
        public static byte[] AES_Decrypt_CBC(byte[] input, byte[] key, byte[] initVector)
        {
            try
            {
                using (MemoryStream msDecrypt = new MemoryStream(input))
                {
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    Aes aesAlg = Aes.Create();
                    aesAlg.Key = key;
                    // Get the initialization vector from the encrypted stream
                    aesAlg.IV = initVector;
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream result = new MemoryStream())
                        {
                            csDecrypt.CopyTo(result);
                            return result.ToArray();
                        }
                    }
                }
            }
            catch(Exception e)
            {
                string asdf = e.Message;
                return new byte[0];
            }
        }

    }
}
