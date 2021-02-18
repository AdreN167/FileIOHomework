using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileIOHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------1-----------------
            var path = "fib.txt";

            string[] resultAsText = null;

            try
            {
                using (var stream = File.OpenRead(path))
                {
                    var data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);

                    resultAsText = System.Text.Encoding.UTF8.GetString(data).Split(' ');
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            var countOfNumbers = resultAsText.Length * 2;
            string fullRow = string.Empty;

            for (int i = 1; i <= countOfNumbers; i++) {
                fullRow = $"{fullRow} {Fibonachi(i)}";
            }

            fullRow = fullRow.Trim();
            
            try
            {
                using (var stream = File.OpenWrite(path))
                {
                    var data = (System.Text.Encoding.UTF8.GetBytes(fullRow));
                    
                    stream.Write(data, 0, fullRow.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            //----------------2-----------------
            var inputPath = "INPUT.TXT";
            var outputPath = "OUTPUT.TXT";
            try
            {
                using (var streamRead = File.OpenText(inputPath))
                {
                    var data = streamRead.ReadLine().Split(' ');

                    using (var streamWrite = File.Open(outputPath, FileMode.OpenOrCreate))
                    {
                        var result = System.Text.Encoding.UTF8.GetBytes((int.Parse(data[0]) + int.Parse(data[1])).ToString());
                        streamWrite.Write(result, 0, result.Length);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

        }

        public static int Fibonachi(int i)
        {
            if (i < 0) return 0;
            if (i == 1) return 1;
            return Fibonachi(i - 1) + Fibonachi(i - 2);
        }

        
    }
}
