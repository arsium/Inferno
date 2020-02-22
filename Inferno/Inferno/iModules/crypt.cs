using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Inferno
{
    internal class crypt
    {

        // Output
        private static dynamic output = new System.Dynamic.ExpandoObject();

        // Extension
        public static string encryptedExtension = ".IEnc";

        // Encrypt string
        public static string EncryptString(string clearText, string EncryptionKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        // Decrypt string
        public static string DecryptString(string cipherText, string EncryptionKey)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        try
                        {
                            cs.Close();
                        }
                        catch (CryptographicException)
                        {
                            output.error = true;
                            core.Exit("Failed to decrypt file. Wrong password!", output, 3);
                        }
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        // Encrypt file
        public static void EncryptFile(string inputFile, string password)
        {
            // Check file
            if(!File.Exists(inputFile))
            {
                output.error = true;
                core.Exit("Failed to encrypt, file " + inputFile + " not found!", output, 1);
            }

            string outputFile = inputFile + encryptedExtension;
            string content = File.ReadAllText(inputFile);
            string encrypted = EncryptString(content, password);
            File.WriteAllText(outputFile, encrypted);
            File.Delete(inputFile);

            output.inFilename = inputFile;
            output.outFilename = outputFile;
            core.Exit("File encrypted", output);
        }

        // Decrypt file
        public static void DecryptFile(string inputFile, string password)
        {
            // Check file
            if (!File.Exists(inputFile))
            {
                output.error = true;
                core.Exit("Failed to decrypt, file " + inputFile + " not found!", output, 1);
            }

            string outputFile = inputFile.Replace(encryptedExtension, "");
            string content = File.ReadAllText(inputFile);
            string decrypted = DecryptString(content, password);
            File.WriteAllText(outputFile, decrypted);
            File.Delete(inputFile);

            output.inFilename = inputFile;
            output.outFilename = outputFile;
            core.Exit("File decrypted", output);
        }
    }
}
