using System;
using System.Collections.Generic;
using System.IO;

namespace RSA
{
    class TextReader
    {
        readonly private string _inputPath = @"..\..\..\Input.txt";
        readonly private string _encodePath = @"..\..\..\Encode.txt";
        readonly private string _decodePath = @"..\..\..\Decode.txt";

        public string ReadText()
        {
            string text = "";

            try
            {
                using (StreamReader streamReader = new StreamReader(_inputPath))
                {
                    text = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return text;
        }

        public List<string> ReadEncodeText()
        {
            List<string> input = new List<string>();

            StreamReader sr = new StreamReader(_encodePath);

            while (!sr.EndOfStream)
            {
                input.Add(sr.ReadLine());
            }

            sr.Close();

            return input;
        }

        public void WriteEncodeText(List<string> encodeText)
        {
            StreamWriter swEncode = new StreamWriter(_encodePath);

            foreach (string item in encodeText)
                swEncode.WriteLine(item);

            swEncode.Close();

           // WriteText(_encodePath, text);
        }


        public void WriteDecodeText(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_decodePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}