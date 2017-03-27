// ***********************************************************************
// <copyright file="EncryptionHelper.cs" company="Verisk">
//     Copyright © Verisk, All Rights Reserved.
// </copyright>
// <summary>EncryptionHelper Class</summary>
// ***********************************************************************
namespace TSW.B2B.Common.Implementation
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Encryption Helper Class
    /// </summary>
    public class EncryptionHelper
    {
        /// <summary>
        /// This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        ///  32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        /// </summary>
        private const string InitVector = "pemgail9uzpgzl88";

        /// <summary>
        /// This constant is used to determine the keysize of the encryption algorithm
        /// </summary>
        private const int Keysize = 256;

        /// <summary>
        /// Decrypting String
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns>
        /// returns decrypted string
        /// </returns>
        // Decrypt
        public static string DecryptString(string cipherText, string passPhrase)
        {
            if (!string.IsNullOrEmpty(cipherText))
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
                byte[] keyBytes = password.GetBytes(Keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                    memoryStream.Close();
                    cryptoStream.Close();
                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Encrypting String
        /// </summary>
        /// <param name="plainText">plain text</param>
        /// <param name="passPhrase">pass phrase</param>
        /// <returns>Returns encrypted string</returns>
        public static string EncryptString(string plainText, string passPhrase)
        {
            if (!string.IsNullOrEmpty(plainText))
            {
                byte[] initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
                byte[] keyBytes = password.GetBytes(Keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    byte[] cipherTextBytes = memoryStream.ToArray();
                    memoryStream.Close();
                    cryptoStream.Close();
                    return Convert.ToBase64String(cipherTextBytes);
                }
            }

            return string.Empty;
        }
    }
}
