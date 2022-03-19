namespace Eurodiffusion
{
    using System.Text;
    using System;
    using System.IO;

    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder(0);
            using (FileStream fs = new FileStream("input.txt", FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    str.Append(temp.GetString(b));
                }
                
            }

            Grid grid = new Grid(Initializer.Initialize(str.ToString()) );

            grid.StartEuroDiffusion();

            Console.WriteLine(grid.GetResultString());
        }
    }
}
