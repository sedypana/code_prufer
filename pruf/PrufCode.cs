using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruf
{
    public class PrufCode
    {
        int[][] array;

        public PrufCode(int[][] array)
        {
            this.array = array;
        }

        public void Realizing()
        {
            List<int> res = new List<int>();
            List<int> ints = new List<int>();

            for (int i = 0; i < array.Count(); i++)
            {
                for (int j = 0; j < array[i].Count(); j++)
                {
                    if (!ints.Contains(array[i][j]))
                    {
                        ints.Add(array[i][j]);
                    }
                }
            }
            ints.Sort();
            int minrow = -2;
            int mincol = -2;
            bool exm = true;
            while (exm)
            {
                
                for (int n = 0; n < ints.Count(); n++)
                {
                    int minCount = 0;
                    for (int i = 0; i < array.Count(); i++)
                    {
                        for (int j = 0; j < array[i].Count(); j++)
                        {
                            if (ints[n] == array[i][j])
                            {
                                minCount++;
                                minrow = i;
                                mincol = j;
                                
                            }
                        }
                        
                    }
                    if (minCount == 1)
                    {
                        break;
                    }
                }
                if (mincol == 0)
                {
                    res.Add(array[minrow][1]);
                    ints.Remove(array[minrow][mincol]);
                    array[minrow][1] = 0;
                    array[minrow][0] = 0;

                }
                else if (mincol == 1)
                {
                    res.Add(array[minrow][0]);
                    ints.Remove(array[minrow][mincol]);
                    array[minrow][1] = 0;
                    array[minrow][0] = 0;
                }
                int count = 0;
                for (int i = 0; i < array.Count(); i++)
                { 
                    for(int j = 0;j < array[i].Count(); j++)
                    {
                        if (array[i][j] != 0)
                        {
                            count++;
                        }
                    }
                }
                if (count == 2)
                {
                    exm = false;
                }
            }
            Write(res);
            
        }
        public List<int> Write(List<int> res)
        {
            string patch = @"D:\Galochkin\pruf\output.txt";
            FileStream file = new FileStream(patch, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);
            TraceListener listener = new TextWriterTraceListener();
            Trace.AutoFlush = true;

            Console.WriteLine("Код Прюфера:");
            Trace.WriteLine("(TRACE) Код Прюфера:");
            sw.WriteLine("Код Прюфера:");
            for (int i = 0; i < res.Count(); i++)
            {
                Console.Write(res[i] + " ");
                Debug.Write(res[i] + "(DEBUG) ");
                sw.Write(res[i] + " ");
            }
            sw.Close();
            file.Close();
            return res;
        }
    }
}




