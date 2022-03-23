namespace Eurodiffusion
{
    using System.Text;
    using System;
    using System.IO;

    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder();
            try
            {
                using (FileStream fs = new FileStream("input.txt", FileMode.Open))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        str.Append(temp.GetString(b));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Missing input file!" + "\n" +
                                  "Acceptable filename: input.txt" + "\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var parameters = Initializer.Initialize(str.ToString());
            for (int i = 0; i < parameters.Count; i++)
            {
                IAlgorithm algorithm = new SimpleGraph(parameters[i]);
                algorithm.StartEuroDiffusion();

                Console.WriteLine($"Case Number {i + 1}");
                Console.WriteLine(algorithm.GetResultString());
            }
            Console.ReadLine();
        }
    }
}
