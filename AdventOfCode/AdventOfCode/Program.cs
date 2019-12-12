/*
    Santa has become stranded at the edge of the Solar System while delivering presents to other planets!
    To accurately calculate his position in space, safely align his warp drive, and return to Earth in time to save Christmas, he needs you to bring him measurements from fifty stars.
    Collect stars by solving puzzles. Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first. 
    Each puzzle grants one star.
    Good luck!
 */

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            PuzzleSolver puzzleSolver;

            puzzleSolver = new Day1(InputStrings.Day1);
            puzzleSolver = new Day2(InputStrings.Day2);
            puzzleSolver = new Day4(InputStrings.Day4);
            puzzleSolver = new Day8(InputStrings.Day8);
        }
    }
}
