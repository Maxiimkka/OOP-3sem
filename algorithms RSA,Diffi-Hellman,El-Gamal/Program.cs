using System;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        string fullName = "Krivenchuk Maxim";

        // Генерация ключей RSA
        using (var rsa = new RSACryptoServiceProvider())
        {
            // Шифрование ФИО с использованием RSA
            byte[] encryptedData = RSAEncrypt(fullName, rsa.ExportParameters(false));

            // Дешифрование ФИО с использованием RSA
            string decryptedData = RSADecrypt(encryptedData, rsa.ExportParameters(true));

            Console.WriteLine("Шифрование и дешифрование ФИО с использованием RSA:");
            Console.WriteLine("Исходное ФИО: " + fullName);
            Console.WriteLine("Зашифрованное ФИО: " + Convert.ToBase64String(encryptedData));
            Console.WriteLine("Расшифрованное ФИО: " + decryptedData);
            Console.WriteLine();
        }

        // Генерация ключей Диффи-Хеллмана
        using (var dh = new ECDiffieHellmanCng())
        {
            // Шифрование ФИО с использованием Диффи-Хеллмана
            byte[] encryptedData = DHEncrypt(fullName, dh);

            // Дешифрование ФИО с использованием Диффи-Хеллмана
            string decryptedData = DHDecrypt(encryptedData, dh);

            Console.WriteLine("Шифрование и дешифрование ФИО с использованием Диффи-Хеллмана:");
            Console.WriteLine("Исходное ФИО: " + fullName);
            Console.WriteLine("Зашифрованное ФИО: " + Convert.ToBase64String(encryptedData));
            Console.WriteLine("Расшифрованное ФИО: " + decryptedData);
            Console.WriteLine();
        }

        // Генерация ключей Эль-Гамаля
        using (var elGamal = new ECDiffieHellmanCng())
        {
            // Шифрование ФИО с использованием Эль-Гамаля
            byte[] encryptedData = ElGamalEncrypt(fullName, elGamal);

            // Дешифрование ФИО с использованием Эль-Гамаля
            string decryptedData = ElGamalDecrypt(encryptedData, elGamal);

            Console.WriteLine("Шифрование и дешифрование ФИО с использованием Эль-Гамаля:");
            Console.WriteLine("Исходное ФИО: " + fullName);
            Console.WriteLine("Зашифрованное ФИО: " + Convert.ToBase64String(encryptedData));
            Console.WriteLine("Расшифрованное ФИО: " + decryptedData);
        }
        Console.ReadLine();
    }

    // Метод для шифрования ФИО с использованием RSA
    static byte[] RSAEncrypt(string data, RSAParameters rsaParameters)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(rsaParameters);
            return rsa.Encrypt(System.Text.Encoding.UTF8.GetBytes(data), true);
        }
    }

    // Метод для дешифрования ФИО с использованием RSA
    static string RSADecrypt(byte[] encryptedData, RSAParameters rsaParameters)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(rsaParameters);
            byte[] decryptedData = rsa.Decrypt(encryptedData, true);
            return System.Text.Encoding.UTF8.GetString(decryptedData);
        }
    }

    // Метод для шифрования ФИО с использованием Диффи-Хеллмана
    static byte[] DHEncrypt(string data, ECDiffieHellmanCng dh)
    {
        byte[] publicKey = dh.PublicKey.ToByteArray();
        byte[] sharedKey = dh.DeriveKeyMaterial(CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob));
        byte[] encryptedData;

        using (var aes = new AesCryptoServiceProvider())
        {
            aes.Key = sharedKey;
            aes.GenerateIV();

            using (var encryptor = aes.CreateEncryptor())
            using (var memoryStream = new System.IO.MemoryStream())
            {
                // Записываем IV в начало потока
                memoryStream.Write(aes.IV, 0, aes.IV.Length);

                using (var cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, encryptor, System.Security.Cryptography.CryptoStreamMode.Write))
                using (var streamWriter = new System.IO.StreamWriter(cryptoStream))
                {
                    streamWriter.Write(data);
                }

                encryptedData = memoryStream.ToArray();
            }
        }

        return encryptedData;
    }

    // Метод для дешифрования ФИО с использованием Диффи-Хеллмана
    static string DHDecrypt(byte[] encryptedData, ECDiffieHellmanCng dh)
    {
        byte[] publicKey = dh.PublicKey.ToByteArray();
        byte[] sharedKey = dh.DeriveKeyMaterial(CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob));
        byte[] iv = new byte[16];

        using (var aes = new AesCryptoServiceProvider())
        {
            aes.Key = sharedKey;

            // Читаем IV из начала зашифрованных данных
            Array.Copy(encryptedData, iv, iv.Length);
            aes.IV = iv;

            using (var decryptor = aes.CreateDecryptor())
            using (var memoryStream = new System.IO.MemoryStream(encryptedData, iv.Length, encryptedData.Length - iv.Length))
            using (var cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, decryptor, System.Security.Cryptography.CryptoStreamMode.Read))
            using (var streamReader = new System.IO.StreamReader(cryptoStream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }

    // Метод для шифрования ФИО с использованием Эль-Гамаля
    static byte[] ElGamalEncrypt(string data, ECDiffieHellmanCng elGamal)
    {
        byte[] publicKey = elGamal.PublicKey.ToByteArray();
        byte[] sharedKey = elGamal.DeriveKeyMaterial(CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob));
        byte[] encryptedData;

        using (var aes = new AesCryptoServiceProvider())
        {
            aes.Key = sharedKey;
            aes.GenerateIV();

            using (var encryptor = aes.CreateEncryptor())
            using (var memoryStream = new System.IO.MemoryStream())
            {
                // Записываем IV в начало потока
                memoryStream.Write(aes.IV, 0, aes.IV.Length);

                using (var cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, encryptor, System.Security.Cryptography.CryptoStreamMode.Write))
                using (var streamWriter = new System.IO.StreamWriter(cryptoStream))
                {
                    streamWriter.Write(data);
                }

                encryptedData = memoryStream.ToArray();
            }
        }

        return encryptedData;
    }

    // Метод для дешифрования ФИО с использованием Эль-Гамаля
    static string ElGamalDecrypt(byte[] encryptedData, ECDiffieHellmanCng elGamal)
    {
        byte[] publicKey = elGamal.PublicKey.ToByteArray();
        byte[] sharedKey = elGamal.DeriveKeyMaterial(CngKey.Import(publicKey, CngKeyBlobFormat.EccPublicBlob));
        byte[] iv = new byte[16];

        using (var aes = new AesCryptoServiceProvider())
        {
            aes.Key = sharedKey;

            // Читаем IV из начала зашифрованных данных
            Array.Copy(encryptedData, iv, iv.Length);
            aes.IV = iv;

            using (var decryptor = aes.CreateDecryptor())
            using (var memoryStream = new System.IO.MemoryStream(encryptedData, iv.Length, encryptedData.Length - iv.Length))
            using (var cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, decryptor, System.Security.Cryptography.CryptoStreamMode.Read))
            using (var streamReader = new System.IO.StreamReader(cryptoStream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}