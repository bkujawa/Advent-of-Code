using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class PuzzleSolver
    {
        protected virtual string Name { get; set; }
        protected virtual string InputString { get; set; }

        protected void Print()
        {
            Console.WriteLine($"Puzzle solved for {Name}");
            Console.ReadLine();
        }
    }
}
