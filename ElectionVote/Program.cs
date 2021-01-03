﻿using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using ElectionVote.Services;
using ElectionVote.Services.Cryptography;
using ElectionVote.Services.Enums;
using ElectionVote.Services.Exceptions;
using ElectionVote.Services.Interactions;
using ElectionVote.Services.Interactions.Options;
using ElectionVote.Services.Models;

namespace ElectionVote {
    class MainClass {
        public static async System.Threading.Tasks.Task Main(string[] args) {
            Console.WriteLine("Welcome to the Election Voting App!\n");

            User user = await AuthOptionsFlow.Interact();

            //User user = new User() {
            //    FirstName = "Charles",
            //    LastName = "McCarthy",
            //    Email = "charles@test.com",
            //    UserType = UserType.VOTER,
            //    UserId = "3836cd98-fb85-4140-8493-e1e997d58309"
            //};
            CurrentUser.SetCurrentUser(user);

            //Console.Clear();
            Console.WriteLine($"Hi {user.FirstName}!");

            try {
                await OptionsFlow.InteractAsync();
            } catch (LogoutException e) {
                if (e.IsUserInvoked) Console.WriteLine("You have successfully logged out!");
                else Console.WriteLine("You have been forcefully logged out: {0}", e.Message);
                CurrentUser.UnsetCurrentUser(); // Clear user data
            } catch (Exception e) {
                Console.WriteLine("An nunknown exception occurred: {0}", e);
            }

            Console.Read();

            //Encrypt();
            //HMAC();
            //string salt = Console.ReadLine();
            //string password = Console.ReadLine();
            //Test(salt, password);
            //Test2();
        }

        static void Test(string s, string p) {
            //byte[] bytes;
            //using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256)) {
            //    bytes = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            //}

            //var salt = PBKDF2.GenerateSalt();
            var salt = Encoding.ASCII.GetBytes(s);
            //Console.WriteLine(Convert.ToBase64String(salt));

            var hashedPassword = PBKDF2.HashPassword(Encoding.UTF8.GetBytes(p), salt, 50000);

            Console.WriteLine("Hashed Password is {0}", Convert.ToBase64String(hashedPassword));
        }

        static void Test2() {
            //byte[] bytes;
            //using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256)) {
            //    bytes = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            //}

            var salt = PBKDF2.GenerateSalt();
            //var salt = Encoding.ASCII.GetBytes("9QBqhZg8tzzolzqc0ydQhRhjG+JDqaXBVSqittmX/Og=");
            //var salt = Encoding.ASCII.GetBytes(s);

            string saltString = Convert.ToBase64String(salt);
            Console.WriteLine(1);
            Console.WriteLine(saltString);

            byte[] saltTemp = Encoding.ASCII.GetBytes(saltString);

            //Console.WriteLine();

            saltString = Convert.ToBase64String(saltTemp);
            Console.WriteLine(2);
            Console.WriteLine(saltString);

            saltTemp = Encoding.ASCII.GetBytes(saltString);

            //Console.WriteLine();

            saltString = Convert.ToBase64String(saltTemp);
            Console.WriteLine(3);
            Console.WriteLine(saltString);



            var hashedPassword = PBKDF2.HashPassword(Encoding.UTF8.GetBytes("hello123"), salt, 50000);

            Console.WriteLine("Hashed Password is {0}", Convert.ToBase64String(hashedPassword));
        }

        static void Generate() {
            //Generate a public/private key pair.  
            RSA rsa = RSA.Create();

            Console.WriteLine(rsa);
            //Save the public key information to an RSAParameters structure.  
            RSAParameters rsaKeyInfo = rsa.ExportParameters(true);

            Console.WriteLine("P (Decimal Encoding): " + toDecimalEncodedStringValue(rsaKeyInfo.P));
            Console.WriteLine("Q (Decimal Encoding): " + toDecimalEncodedStringValue(rsaKeyInfo.Q));
            Console.WriteLine("D (Decimal Encoding): " + toDecimalEncodedStringValue(rsaKeyInfo.D));
            Console.WriteLine("E (Decimal Encoding): " + toDecimalEncodedStringValue(rsaKeyInfo.Exponent));//Value For E In RSA Key Pair Generated.
            Console.WriteLine("N (Decimal Encoding): " + toDecimalEncodedStringValue(rsaKeyInfo.Modulus));//Value For N In RSA Key Pair Generated.
        }

        static void Encrypt() {

            //Data To Be Encrypted

            string text = "Hello World";
            byte[] plaintext_data = Encoding.ASCII.GetBytes(text);
            Console.WriteLine("Plaintext (ASCII Encoded Text): " + text);
            Console.WriteLine("Plaintext (ASCII Encoded Byte Array): [{0}]", string.Join(", ", plaintext_data));
            Console.WriteLine("");


            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();//Create RSA Cipher Object (Note That An RSA Keypair Is Autogenerated Using This Constructor).

            /*Note That The Paragraph Of Code Below Is For Output Purposes Only*/

            RSAParameters key_parameters = rsa.ExportParameters(true);//RSA - Note That The Boolean Value Inputted Specifies Whether Or Not Private Key Values Are Included In The RSAParmaters Object Generated, i.e. P, Q, Phi and D.
            //Console.WriteLine("RSA Key Pair Values:");
            /*Note That The toDecimalEncodedStringValue() Method Is Defined Below At The End Of This Class.*/
            //Console.WriteLine("P (Decimal Encoding): " + toDecimalEncodedStringValue(key_parameters.P));
            //Console.WriteLine("Q (Decimal Encoding): " + toDecimalEncodedStringValue(key_parameters.Q));
            //Console.WriteLine("E (Decimal Encoding): " + toDecimalEncodedStringValue(key_parameters.Exponent));//Value For E In RSA Key Pair Generated.
            //Console.WriteLine("D (Decimal Encoding): " + toDecimalEncodedStringValue(key_parameters.D));
            //Console.WriteLine("N (Decimal Encoding): " + toDecimalEncodedStringValue(key_parameters.Modulus));//Value For N In RSA Key Pair Generated.
            //Console.WriteLine("");

            //Perform Encryption

            byte[] ciphertext_data = rsa.Encrypt(plaintext_data, true);//Perform RSA Encryption - Note That The Boolean Value Inputted Indicates Whether Or Not OAEP Padding Is Utilised (Recommended).
            Console.WriteLine("Ciphertext (Byte Array): [{0}]", string.Join(", ", ciphertext_data));
            Console.WriteLine("Ciphertext (Base64 Encoding): " + Convert.ToBase64String(ciphertext_data));
            Console.WriteLine("");

            //Perform Decryption

            Console.WriteLine(rsa.ExportParameters(true));

            plaintext_data = rsa.Decrypt(ciphertext_data, true);//Perform RSA Decryption - The Boolean Value Inputted Indicates Whether Or Not OAEP Padding Is Utilised (Recommended).
            Console.WriteLine("Plaintext (ASCII Encoded Byte Array): [{0}]", string.Join(", ", plaintext_data));
            text = Encoding.ASCII.GetString(plaintext_data);
            Console.WriteLine("Plaintext (ASCII Encoded Text): " + text);
            Console.WriteLine("");

            Console.ReadLine();

        }

        public static String toDecimalEncodedStringValue(byte[] byteArrayIn) {

            /*
             * In Order To Convert The Inputted Byte Array To A Decimal Encoded Integer, We Need To Use The BigInteger 
             * Class, As The Size Of The Values Used For RSA Keys Exceeds The Range Of Values Supported By The Long Primitive 
             * Type In C#.NET. We Will Then Call The toString() Method On The BigInteger Object That Gets Created.
             * 
             * The BigInteger(byte[]) Constructor Assumes That The Byte Array Inputted Represents A Signed Integer Value 
             * With Litlle-Endian (LE) Byte Ordering.
             * 
             * Unfortunatelty, All Byte Arrays Returned By 'RSAParameters' Objects Are Representened As Unsigned Integer Values 
             * With Big-Endian (BE) Byte Ordering. 
             * 
             * Note That An Explanation Of Bit/Byte Endianess Can Be Found At https://en.wikipedia.org/wiki/Endianness
             * 
             * To Change The Endianess Of A Byte Arrays, We Simply Reverse The Order Of The Data Contained Within The Byte 
             * Array, i.e. The Last Item In The Array Becomes The First, The Second Last Item Becomes The Second Item, etc.
             * 
             * To Change The Value From An Unsigned Integer Value To A Signed Integer Value, We Examine The Last Element In A
             * Little-Endian Ordered Byte Array. Note That All Values Used In RSA Are Positive Integers - As Such, We Need To 
             * Avoid The Possibility Of The Signed Integer Value Becoming A Negative Value When Converted To A Signed Integer.
             * 1) If The Value Of The Last Array Element Is Less Than Or Equal To 127, We Can Convert The Byte Array As Is 
             * (<=127 Implies A Positive Signed Value).
             * 2) If The Value At This Location Exceeds 127, The Integer Will Be Rendered As A Negative Value When Converted To A 
             * Signed Integer Value. To Prevent This, We Append An Additional Byte To The Byte Array And Insert The Value Zero
             * At This Location (Zero Denoting That The Signed Integer Value Is Positive).
             * 
             */

            Array.Reverse(byteArrayIn, 0, byteArrayIn.Length);//Reverse Endianess Of Byte Array Inputted

            //If Value In Last Byte Exceeds 127, Value Will Be Reendered As Negative. Steps To Prevent This Are Inside IF Statement

            if (byteArrayIn[byteArrayIn.Length - 1] > 127) {
                Array.Resize(ref byteArrayIn, byteArrayIn.Length + 1);//Add An Extra Element To The Byte Array.
                byteArrayIn[byteArrayIn.Length - 1] = 0;//Set Value Of Last Byte To Zero To Render As Positive Integer Value.
            }

            BigInteger number = new BigInteger(byteArrayIn);//Create BigInteger Object From Byte Array.

            return number.ToString();//Return String Value Showing The Number In Decimal Form.

        }




        public static void HashFunctions() {

            string text = "Hello World";
            byte[] data = Encoding.ASCII.GetBytes(text);
            Console.WriteLine("Data (ASCII Encoded Text): " + text);
            Console.WriteLine("Data (ASCII Encoded Byte Array): [{0}]", string.Join(", ", data));
            Console.WriteLine("");

            HashAlgorithm hash_alg_object = SHA256.Create();//Create Instance Of Hash Algorithm
            byte[] hash_value = hash_alg_object.ComputeHash(data);//Calculate Hash Value
            String hex_encoded_hash_value = BitConverter.ToString(hash_value);//Return Hexadecimal Encoded String Value
            String hex_encoded_hash_value_no_separators = hex_encoded_hash_value.Replace("-", "");
            Console.WriteLine("Hash Value (SHA256 Byte Array): [{0}]", string.Join(", ", hash_value));
            Console.WriteLine("Hash Value (SHA256 Hexadecimal Encoded String): " + hex_encoded_hash_value);
            Console.WriteLine("Hash Value (SHA256 Hexadecimal Encoded String - No Separator): " + hex_encoded_hash_value_no_separators);
            Console.WriteLine("");

        }



        public static void HMAC() {

            string text = "Hello World";
            byte[] data = Encoding.ASCII.GetBytes(text);
            Console.WriteLine("Data (ASCII Encoded Text): " + text);
            Console.WriteLine("Data (ASCII Encoded Byte Array): [{0}]", string.Join(", ", data));
            Console.WriteLine("");

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] key = new byte[8];
            rng.GetBytes(key);
            string base64_key_string = Convert.ToBase64String(key);
            Console.WriteLine("Random Key Generated (Byte Array): [{0}]", string.Join(", ", key));
            Console.WriteLine("Random Key Generated (Base64): " + base64_key_string);//Output
            Console.WriteLine("");

            HMAC hmac = new HMACSHA256(key);
            byte[] keyed_hash_value = hmac.ComputeHash(data);//Calculate Hash Value
            String hex_encoded_keyed_hash_value = BitConverter.ToString(keyed_hash_value);//Return Hexadecimal Encoded String Value
            String hex_encoded_keyed_hash_value_no_separators = hex_encoded_keyed_hash_value.Replace("-", "");
            Console.WriteLine("Hash Value (SHA256 Byte Array): [{0}]", string.Join(", ", keyed_hash_value));
            Console.WriteLine("Hash Value (SHA256 Hexadecimal Encoded String): " + hex_encoded_keyed_hash_value);
            Console.WriteLine("Hash Value (SHA256 Hexadecimal Encoded String - No Separator): " + hex_encoded_keyed_hash_value_no_separators);
            Console.WriteLine("");

        }

    }
}
