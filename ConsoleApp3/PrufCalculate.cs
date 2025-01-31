using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp3
{
    public class PrufCodeCalculator
    {
        private readonly Graph _graph;

        public PrufCodeCalculator(Graph graph)
        {
            _graph = graph;
        }

        public List<int> Calculate()
        {
            List<int> result = new List<int>();
            List<int> uniqueValues = _graph.GetUniqueValues();

            while (true)
            {
                int minRowIndex = -1;

                foreach (int value in uniqueValues)
                {
                    if (_graph.CountOccurrences(value) == 1)
                    {
                        for (int i = 0; i < _graph.Count; i++)
                        {
                            if (_graph[i, 0] == value || _graph[i, 1] == value)
                            {
                                minRowIndex = i;
                                break;
                            }
                        }
                        break; // Найден уникальный элемент, выходим из цикла
                    }
                }

                if (minRowIndex == -1) break; // Если уникальный элемент не найден

                result.Add(_graph[minRowIndex, 0] != 0 ? _graph[minRowIndex, 1] : _graph[minRowIndex, 0]);
                _graph.RemoveNode(minRowIndex);

                if (_graph.RemainingCount() <= 2) break;
            }

            return result;
        }
    }
}
