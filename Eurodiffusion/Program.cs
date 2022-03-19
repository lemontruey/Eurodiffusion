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
            using (FileStream fs = new FileStream("input.txt", FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    str.Append(temp.GetString(b));
                }
            }

            var parameters = Initializer.Initialize(str.ToString());
            for (int i = 0; i < parameters.Count; i++)
            {
                Grid grid = new Grid(parameters[i]);

                grid.StartEuroDiffusion();

                Console.WriteLine($"Case Number {i + 1}");
                Console.WriteLine(grid.GetResultString());
            }
            Console.ReadLine();
        }
    }
}
