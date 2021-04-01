using System;
using System.Collections.Generic;
using System.Text;

namespace RSA
{
    class RSA
    {
        private char[] characters = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                                                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                                                'u', 'v', 'w', 'x', 'y', 'z'};

        public int p;
        public int q;
        public int r;
        public int PHI_r;
        public int e;
        public int d;

        public RSA(int p, int q)
        {
            this.p = p;
            this.q = q;

            Calculate_r_PHI_r();
            e = Calculate_E();
            EUCLID_d(PHI_r, e);

        }
        private void GeneratePQ()
        {
            p = 3;
            q = 11;
        }

        private void Calculate_r_PHI_r()
        {
            r = p * q;
            PHI_r = (p - 1) * (q - 1);
        }

        public static bool IsCoprime(int a, int b)
        {
            return a == b
                   ? a == 1
                   : a > b
                        ? IsCoprime(a - b, b)
                        : IsCoprime(b - a, a);
        }

        private int Calculate_E()
        {
            for (int i = 2; i < PHI_r; i++)
            {
                if (IsCoprime(PHI_r, i))
                {
                    return i;
                }
            }
            return 0;
        }

        private void EUCLID_d(int a, int b)
        {
            int d0 = a;
            int d1 = b;
            int x0 = 1;
            int x1 = 0;
            int y0 = 0;
            int y1 = 1;
            while (d1 > 1)
            {
                int q = d0 / d1;
                int d2 = d0 % d1;
                int x2 = x0 - q * x1;
                int y2 = y0 - q * y1;
                d0 = d1;
                d1 = d2;
                x0 = x1;
                x1 = x2;
                y0 = y1;
                y1 = y2;
            }

            if (y1 < 0)
            {
                d = y1 + PHI_r;
            }
            else
            {
                d = y1;
            }
            //Console.WriteLine("{0}*{1}+{2}*{3}={4}", x1, a, y1, b, d1);
        }

        private int fast_exp(int a, int z, int n)
        {
            int a1 = a;
            int z1 = z;
            int x = 1;
            while (z1 != 0)
            {
                while ((z1 % 2) == 0)
                {
                    z1 = z1 / 2;
                    a1 = (a1 * a1) % n;
                }
                z1--;
                x = (x * a1) % n;
            }
            return x;
        }

        public List<string> EnryptRSA(string InPut, int e, int r)
        {
            List<string> OutPut = new List<string>();

            for (int i = 0; i < InPut.Length; i++)
            {
                int index = Array.IndexOf(characters, InPut[i]);
                int Number = fast_exp(index, e, r);
                Console.WriteLine($"{index} - {Number}");

                OutPut.Add(Number.ToString());
                //OutPut += Convert.ToChar(Number);
            }
            return OutPut;
        }
        public string DecryotRSA(List<string> InPut1, int d1, int r1)
        {
            string OutPut1 = "";

            for (int i = 0; i < InPut1.Count; i++)
            {
                int index1 = Convert.ToInt32(InPut1[i]);
                int Number1 = fast_exp(index1, d1, r1);
                Console.WriteLine($"{index1} - {Number1}");

                OutPut1 += characters[Number1];
            }

            return OutPut1;
        }

    }
}
