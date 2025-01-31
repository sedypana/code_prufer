using ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Graph
    {
        private readonly List<List<int>> _adjacencyList;

        public Graph(int[][] adjacencyMatrix)
        {
            if (adjacencyMatrix == null)
                throw new PrufCodeException("Матрица смежности не может быть null.");

            _adjacencyList = adjacencyMatrix.Select(row => row.ToList()).ToList();
        }

        public List<int> GetUniqueValues()
        {
            return _adjacencyList.SelectMany(row => row)
                                 .Distinct()
                                 .OrderBy(value => value)
                                 .ToList();
        }

        public int CountOccurrences(int value)
        {
            return _adjacencyList.Sum(row => row.Count(v => v == value));
        }

        public void RemoveNode(int rowIndex)
        {
            for (int j = 0; j < _adjacencyList[rowIndex].Count; j++)
            {
                _adjacencyList[rowIndex][j] = 0; // Удаляем узел, устанавливая его значение в 0
            }
        }

        public int RemainingCount()
        {
            return _adjacencyList.Sum(row => row.Count(value => value != 0));
        }

        public int this[int rowIndex, int colIndex] => _adjacencyList[rowIndex][colIndex];
        public int Count => _adjacencyList.Count;
    }
}
