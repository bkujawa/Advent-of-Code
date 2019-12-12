using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day4 : PuzzleSolver
    {
        private int lowerBoundary;
        private int upperBoundary;
        private List<int> numbers;

        public Day4(string inputString)
        {
            Name = "Day Four";
            InputString = inputString;
            var input = File.ReadAllLines(InputString);
            this.lowerBoundary = int.Parse(input[0]);
            this.upperBoundary = int.Parse(input[1]);

            SolvePuzzles();
        }

        private void SolvePuzzles()
        {
            PuzzleOne();
            PuzzleTwo();
            Print();
        }

        private void PuzzleOne()
        {
            int numberOfPasswordsMatchingCriteria = 0;
            for (int i = this.lowerBoundary; i < this.upperBoundary; ++i)
            {
                this.numbers = ConvertIntToList(i);
                if (IncreasingNumbersRule() && TwoAdjacentDigitsRule())
                {
                    numberOfPasswordsMatchingCriteria++;
                }
            }
            Console.WriteLine($"Puzzle one answer: {numberOfPasswordsMatchingCriteria}");
        }

        private void PuzzleTwo()
        {
            int numberOfPasswordsMatchingCriteria = 0;
            for (int i = this.lowerBoundary; i < this.upperBoundary; ++i)
            {
                this.numbers = ConvertIntToList(i);
                if (IncreasingNumbersRule() && TwoAdjacentDigitsNotInPackRule())
                {
                    numberOfPasswordsMatchingCriteria++;
                }
            }
            Console.WriteLine($"Puzzle two answer: {numberOfPasswordsMatchingCriteria}");
        }

        private bool TwoAdjacentDigitsNotInPackRule()
        {
            int repeats = 1;
            bool twoDigitsNotInPackRule = false;
            for (int i = 0; i < this.numbers.Count - 1; ++i)
            {
                if (this.numbers[i] == this.numbers[i + 1])
                {
                    ++repeats;
                    if (repeats == 2)
                    {
                        twoDigitsNotInPackRule = true;
                    }
                    else
                    {
                        twoDigitsNotInPackRule = false;
                    }
                }
                else
                {
                    if (twoDigitsNotInPackRule)
                    {
                        return true;
                    }
                    else
                    {
                        repeats = 1;
                    }
                }
            }
            return twoDigitsNotInPackRule;
        }

        private bool TwoAdjacentDigitsRule()
        {
            for (int i = 0; i < this.numbers.Count - 1; ++i)
            {
                if (this.numbers[i] == this.numbers[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        private bool IncreasingNumbersRule()
        {
            for (int i = 0; i < this.numbers.Count - 1; ++i)
            {
                if (this.numbers[i] > this.numbers[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        private List<int> ConvertIntToList(int password)
        {
            var result = new List<int>();
            while (password != 0)
            {
                result.Add(password % 10);
                password /= 10;
            }
            result.Reverse();
            return result.ToList();
        }
    }
}
/*
-------------- Day 4: Secure Container --------------

        -------------- Puzzle One --------------
        You arrive at the Venus fuel depot only to discover it's protected by a password. 
        The Elves had written the password on a sticky note, but someone threw it out.

        However, they do remember a few key facts about the password:
            - It is a six-digit number.
            - The value is within the range given in your puzzle input.
            - Two adjacent digits are the same (like 22 in 122345).
            - Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679).

        Other than the range rule, the following are true:
            - 111111 meets these criteria (double 11, never decreases).
            - 223450 does not meet these criteria(decreasing pair of digits 50).
            - 123789 does not meet these criteria(no double).

        How many different passwords within the range given in your puzzle input meet these criteria?

        -------------- Puzzle Two --------------
        An Elf just remembered one more important detail: the two adjacent matching digits are not part of a larger group of matching digits.

        Given this additional criterion, but still ignoring the range rule, the following are now true:
            - 112233 meets these criteria because the digits never decrease and all repeated digits are exactly two digits long.
            - 123444 no longer meets the criteria (the repeated 44 is part of a larger group of 444).
            - 111122 meets the criteria (even though 1 is repeated more than twice, it still contains a double 22).

        How many different passwords within the range given in your puzzle input meet all of the criteria?
*/
