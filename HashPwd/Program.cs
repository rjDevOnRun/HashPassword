using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashPwd
{
    class Program
    {
        static void Main(string[] args)
        {
            string pwdToUse = "Test123";

            string hashedPwd = EncryptionHelper.Encrypt(pwdToUse);

            string decrytedPwd = EncryptionHelper.Decrypt(hashedPwd);

        }

        private static void Method1(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"Insufficeint arguments provided. " +
                    $"Usage for Encoding: HashPwd 'password_string' 'e' " +
                    $"Usage for DeCoding: HashPwd 'password_string' 'd'"
                    );
                return;
            }

            // get password string
            string inputString = args[0];
            string actionToDo = args[1];

            // create encoded/hashed password string
            string encodedPassword = EncodeThisPassword(inputString);
        }

        private static string EncodeThisPassword(string stringToEncode)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(stringToEncode);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);

            return Convert.ToBase64String(inArray);
        }
    }
}
