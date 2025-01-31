using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Program
    {
        public static int[][] ConvertToIntArray(string[] lines) => lines.Select(line => line.Split(' ').Select(int.Parse).ToArray()).ToArray();
        public static void Main(string[] args)
        {
            string inputpath = "D:\\input.txt";
            string outputPath = "D:\\output.txt";
            string[] lines = File.ReadAllLines(inputpath);

            int[][] arr = ConvertToIntArray(lines);

            Graph graph = new Graph(arr);
            PrufCodeCalculator calc = new PrufCodeCalculator(graph);
            List<int> res = calc.Calculate();
            ResultWriter writer = new ResultWriter(outputPath);
            writer.Write(res);
            Console.ReadLine();
        }
    }
}
