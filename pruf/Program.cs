using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruf
{
    public class Program
    {
        static int[][] ConvertToIntArray(string[] lines) => lines.Select(line => line.Split(' ').Select(int.Parse).ToArray()).ToArray();
        static void Main(string[] args)
        {
            string path = @"D:\Galochkin\pruf\input.txt";
            string[] lines = File.ReadAllLines(path);

            int[][] arr = ConvertToIntArray(lines);

            PrufCode obj = new PrufCode(arr);
            obj.Realizing();
            Console.ReadLine();
        }
    }
}
