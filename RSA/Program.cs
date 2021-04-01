using System;
using System.Collections.Generic;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsa = new RSA(101, 103);
            Console.WriteLine($"P:{rsa.p}, Q:{rsa.q}, D:{rsa.d},E:{rsa.e},PHI_R:{rsa.PHI_r},R:{rsa.r}.");
            string InPut = "hello";
            Console.WriteLine($"{InPut}");
            List<string> strEncrypted = rsa.EnryptRSA(InPut, rsa.e, rsa.r);
            foreach (string i in strEncrypted)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            string result = rsa.DecryotRSA(strEncrypted, rsa.d, rsa.r);
            Console.WriteLine($"{result}");

            Console.WriteLine("END.");
        }
    }
}
