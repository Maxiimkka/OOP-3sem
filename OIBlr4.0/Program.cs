using System;
using SecurityLibrary.DiffieHellman;
using SecurityLibrary.AES;
using SecurityLibrary.ElGamal;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        // Ввод текста для шифрования
        Console.WriteLine("Введите текст для шифрования: ");
        string originalText = Console.ReadLine();

        // Шифрование и расшифрование с использованием RSA
        Console.WriteLine("RSA:");
        RSAEncryption(originalText);

        // Шифрование и расшифрование с использованием Диффи-Хеллман
        Console.WriteLine("\nДиффи-Хеллман:");
        DiffieHellmanEncryption(originalText);

        // Шифрование и расшифрование с использованием Эль-Гамаля
        Console.WriteLine("\nЭль-Гамаля:");
        ElGamalEncryption(originalText);
    }

    static void RSAEncryption(string originalText)
    {
        try
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                RSAParameters publicKey = rsa.ExportParameters(false);
                RSAParameters privateKey = rsa.ExportParameters(true);

                byte[] encryptedData = EncryptData(originalText, publicKey);
                string decryptedText = DecryptData(encryptedData, privateKey);

                Console.WriteLine("Исходный текст: " + originalText);
                Console.WriteLine("Зашифрованный текст (RSA): " + BitConverter.ToString(encryptedData));
                Console.WriteLine("Расшифрованный текст (RSA): " + decryptedText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    static byte[] EncryptData(string data, RSAParameters publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(publicKey);
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] encryptedData = rsa.Encrypt(dataBytes, false);
            return encryptedData;
        }

        static string DecryptData(byte[] encryptedData, RSAParameters privateKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);
                byte[] decryptedBytes = rsa.Decrypt(encryptedData, false);
                return System.Text.Encoding.UTF8.GetString(decryptedBytes);
            }
        }

        static void DiffieHellmanEncryption(string originalText)
        {
            try
            {
                // Создаем объект для Диффи-Хеллман
                DiffieHellman dh = new DiffieHellman();

                // Генерируем ключи
                dh.GenerateKeys();
                int publicKeyA = dh.GetPublicKey();
                int sharedKeyA = dh.GetSharedKey(publicKeyA);

                // Шифрование и расшифрование
                string encryptedText = dh.EncryptText(originalText, sharedKeyA);
                string decryptedText = dh.DecryptText(encryptedText, sharedKeyA);

                Console.WriteLine("Исходный текст: " + originalText);
                Console.WriteLine("Зашифрованный текст (Диффи-Хеллман): " + encryptedText);
                Console.WriteLine("Расшифрованный текст (Диффи-Хеллман): " + decryptedText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

        static void ElGamalEncryption(string originalText)
        {
            try
            {
                // Создаем объект для Эль-Гамаля
                ElGamal elGamal = new ElGamal();

                // Генерируем ключи
                elGamal.GenerateKeys();
                int publicKeyY = elGamal.GetPublicKeyY();
                int privateKeyX = elGamal.GetPrivateKeyX();

                // Шифрование и расшифрование
                Tuple<int, int> encryptedText = elGamal.EncryptText(originalText, publicKeyY);
                string decryptedText = elGamal.DecryptText(encryptedText, privateKeyX);

                Console.WriteLine("Исходный текст: " + originalText);
                Console.WriteLine("Зашифрованный текст (Эль-Гамаля): C1=" + encryptedText.Item1 + ", C2=" + encryptedText.Item2);
                Console.WriteLine("Расшифрованный текст (Эль-Гамаля): " + decryptedText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}