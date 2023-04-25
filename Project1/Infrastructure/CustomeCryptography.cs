using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Infrastructure
{
    public static class CustomeCryptography
    {
        public static string Encrypt(string text,string EncryptionKey)
        {
            byte[] textbytes = Encoding.Unicode.GetBytes(text);
            Aes encryptor = Aes.Create();
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(textbytes, 0, textbytes.Length);
            cs.Close();
            text = Convert.ToBase64String(ms.ToArray());
            return text;
        }

        public static string Decrypt(string CipherText,string EncryptionKey)
        {
            byte[] CipherBytes = Convert.FromBase64String(CipherText);
            Aes encryptor = Aes.Create();
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(CipherBytes, 0, CipherBytes.Length);
            cs.Close();
            CipherText = Encoding.Unicode.GetString(ms.ToArray());
            return CipherText;
        }
    }
}
