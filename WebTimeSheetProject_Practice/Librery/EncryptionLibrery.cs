using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebTimeSheetProject_Practice.Librery
{
    public class EncryptionLibrery
    {
        public static byte[] as_encrypt(byte[] bytetoencrypt, byte[] passtoencrypt)
        {
            byte[] encryptedbyte = null;
            byte[] saltbyte = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    var key = new Rfc2898DeriveBytes(passtoencrypt, saltbyte, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;
                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytetoencrypt, 0, bytetoencrypt.Length);
                        cs.Close();
                    }
                    encryptedbyte = ms.ToArray();
                }
            }
            return encryptedbyte;


        }

        public static string EncryptText(string input, string password = "E6t187^D43%F")
        {
            try
            {
                // Get the bytes of the string
                byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Hash the password with SHA256
                passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

                byte[] bytesEncrypted = as_encrypt(bytesToBeEncrypted, passwordBytes);

                string result = Convert.ToBase64String(bytesEncrypted);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}