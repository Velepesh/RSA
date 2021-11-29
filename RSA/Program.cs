using System.Collections.Generic;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader textReader = new TextReader();
            RSA rsa = new RSA();

            string text = textReader.ReadText();

            List<string> encodeResult = rsa.Endoce(text);
            textReader.WriteEncodeText(encodeResult);

            List<string> input = textReader.ReadEncodeText();

            string decodeResult = rsa.Dedoce(input);
            textReader.WriteDecodeText(decodeResult);
        }
    }
}