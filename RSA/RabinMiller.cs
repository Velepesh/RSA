using System;
using System.Numerics;

namespace RSA
{
    class RabinMiller
    {
        readonly int _maxPrimeNumber = 10000;

        private Random _random = new Random();

        public int GetPrimeNumber()
        {
            int value = _random.Next(_maxPrimeNumber);

            while (IsPrimeNumber(value) == false)
                value = _random.Next(_maxPrimeNumber);

            return value;
        }

        private bool IsPrimeNumber(int n)
        {
            long k = (long)(Math.Log10(n) / Math.Log10(2));

            if (n == 2)
                return true;

            if (n < 2 || n % 2 == 0)
                return false;

            int r = 0, s = n - 1;

            while (s % 2 == 0)
            {
                s /= 2;
                r++;
            }

            Random random = new Random();

            for (int i = 0; i < k; i++)
            {
                int a = random.Next(2, n - 1);
                BigInteger x = BigInteger.ModPow(a, s, n);

                if (x == 1 || x == n - 1)
                    continue;

                for (int j = 0; j < r - 1; j++)
                {
                    x = BigInteger.ModPow(x, 2, n);

                    if (x == 1)
                        return false;

                    if (x == n - 1)
                        break;
                }

                if (x != n - 1)
                    return false;
            }

            return true;
        }
    }
}