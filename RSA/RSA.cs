using System;
using System.Collections.Generic;
using System.Numerics;

namespace RSA
{
    class RSA
    {
        private RabinMiller _rabinMiller = new RabinMiller();
        private char[] _alphabet = new char[] 
        { 
            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й',
            'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
            'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я',
            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',  'й',
            'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф',
            'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ', 'э', 'ю', 'я',
            ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
            '#', ',', '.', ':', '!', '?', '№', '-', '?', ':', '(', 
            ')', ';', '"', '\r', '\n'
        };
        private long _n = -1;
        private long _d = -1;

        public List<string> Endoce(string text)
        {
            List<string> result = new List<string>();
            int p = _rabinMiller.GetPrimeNumber();
            int q = _rabinMiller.GetPrimeNumber();
            BigInteger c = -1;

            if (p == q)
                while(p == q)
                    q = _rabinMiller.GetPrimeNumber();

            _n = p * q;

            long m = (p - 1) * (q - 1);
            _d = CalculateD(m);

            long e = CalculateE(_d, m);

            for (int i = 0; i < text.Length; i++)
            {
                int index = Array.IndexOf(_alphabet, text[i]);

                c = new BigInteger(index);
                c = BigInteger.ModPow(c, (int)e, (int)_n);

                result.Add(c.ToString());
            }

            return result;
        }

        public string Dedoce(List<string> input)
        {
            string result = "";
            BigInteger m = -1;

            if (_d > 0 && _n > 0)
            {
                foreach (string item in input)
                {
                    m = new BigInteger(Convert.ToDouble(item));
                    m = BigInteger.ModPow(m, (int)_d, (int)_n);

                    int index = Convert.ToInt32(m.ToString());
                    result += _alphabet[index].ToString();
                }
            }
            else
            {
                throw new Exception();
            }

            return result;
        }

        private long CalculateD(long m)
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
            {
                if (m % i == 0 && d % i == 0)
                {
                    d--;
                    i = 1;
                }
            }
        
            return d;
        }

        private long CalculateE(long d, long m)
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }

            return e;
        }
    }
}