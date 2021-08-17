using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DMSOnlineStore.Infrastructure.StringSetting
{
   public static class Encrypt
    {
        public static string ToEncrypt(this string password)
        {
            const string encryptionKey = "abc123";
            var clearBytes = Encoding.Unicode.GetBytes(password);
            using var encryptor = Aes.Create();
            var pdb = new Rfc2898DeriveBytes(encryptionKey,
                new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            if (encryptor == null) return password;
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
                CryptoStreamMode.Write))
            {
                cs.Write(clearBytes, 0, clearBytes.Length);
                cs.Close();
            }
            password = Convert.ToBase64String(ms.ToArray());
            return password;
        }

    }
}
