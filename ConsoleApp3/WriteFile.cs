using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    // Класс для записи результата в файл
    public class ResultWriter
    {
        private readonly string _outputPath;

        public ResultWriter(string outputPath)
        {
            _outputPath = outputPath;
        }

        public void Write(List<int> result)
        {
            FileStream fs = new FileStream(_outputPath, FileMode.OpenOrCreate);
            using StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("Код Прюфера:");
            sw.WriteLine("Код Прюфера:");
            foreach (int value in result)
            {
                Console.Write(value + " ");
                sw.Write(value + " ");
            }
        }
    }
}
