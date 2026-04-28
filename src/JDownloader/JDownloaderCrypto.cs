using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JDownloader
{
    internal static class JDownloaderCrypto
    {
        #region Secret keys and encryption tokens

        internal static byte[] GetSecret(string email, string password, string domain)
        {
            // Ensure email is lowercase
            byte[] bytes = Encoding.UTF8.GetBytes(email.ToLower() + password + domain);

            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(bytes);
            }
        }

        internal static byte[] GetEncryptionToken(byte[] secret, string sessionToken)
        {
            byte[] sessionTokenBytes = Enumerable.Range(0, sessionToken.Length)
                 .Where(x => x % 2 == 0)
                 .Select(x => Convert.ToByte(sessionToken.Substring(x, 2), 16))
                 .ToArray();

            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(secret.Concat(sessionTokenBytes).ToArray());
            }
        }

        #endregion Secret keys and encryption tokens

        #region Request encryption, decryption and signing

        internal static string GetSignature(string data, byte[] key)
        {
            // HMAC the data
            using (HMACSHA256 hmacsha256 = new HMACSHA256(key))
            {
                byte[] hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(data));

                // Hex format the result
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            }
        }

        internal static async Task<string> Encrypt(string data, byte[] key)
        {
            // AES 128 CBC
            using (Aes aes = Aes.Create())
            {
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.IV = key.Take(key.Length / 2).ToArray(); // First half
                aes.Key = key.Skip(key.Length / 2).ToArray(); // Second half

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        await streamWriter.WriteAsync(data);
                    }

                    byte[] encryptedBytes = memoryStream.ToArray();

                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        internal static async Task<string> Decrypt(string data, byte[] key)
        {
            // AES 128 CBC
            byte[] base64DecryptedBytes = Convert.FromBase64String(data);

            using (Aes aes = Aes.Create())
            {
                aes.BlockSize = 128;
                aes.Mode = CipherMode.CBC;
                aes.IV = key.Take(key.Length / 2).ToArray(); // First half
                aes.Key = key.Skip(key.Length / 2).ToArray(); // Second half

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                using (MemoryStream memoryStream = new MemoryStream(base64DecryptedBytes))
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                using (StreamReader streamReader = new StreamReader(cryptoStream))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
        }

        #endregion Request encryption, decryption and signing
    }
}
