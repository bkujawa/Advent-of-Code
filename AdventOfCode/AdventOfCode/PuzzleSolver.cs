using System;

namespace AdventOfCode
{
    public class PuzzleSolver
    {
        protected virtual string Name { get; private set; }
        protected virtual string InputString { get; private set; }

        protected PuzzleSolver(string name, string inputString)
        {
            Name = name;
            InputString = inputString;
        }

        protected void Print()
        {
            Console.WriteLine($"Puzzle solved for {Name}");
            Console.ReadLine();
        }
    }
}
