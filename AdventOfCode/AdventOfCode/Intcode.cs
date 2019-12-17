using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Intcode
    {
        private static int Add(List<int> program, int programPointer, int firstParamterMode, int secondParameterMode)
        {
            int value1, value2;
            if (firstParamterMode == 0)
            {
                int argument = program[++programPointer];
                value1 = program[argument];
            }
            else
            {
                value1 = program[++programPointer];
            }

            if (secondParameterMode == 0)
            {
                int argument = program[++programPointer];
                value2 = program[argument];
            }
            else
            {
                value2 = program[++programPointer];
            }

            int saveArgument = program[++programPointer];
            program[saveArgument] = value1 + value2;

            return ++programPointer;
        }

        private static int Multiply(List<int> program, int programPointer, int firstParameterMode = 0, int secondParameterMode = 0)
        {
            int value1, value2;
            if (firstParameterMode == 0)
            {
                int argument = program[++programPointer];
                value1 = program[argument];
            }
            else
            {
                value1 = program[++programPointer];
            }

            if (secondParameterMode == 0)
            {
                int argument = program[++programPointer];
                value2 = program[argument];
            }
            else
            {
                value2 = program[++programPointer];
            }
            int saveArgument = program[++programPointer];
            program[saveArgument] = value1 * value2;

            return ++programPointer;
        }

        private static int StoreValue(List<int> program, int programPointer, int firstParameterMode, int argument, int input)
        {
            if (firstParameterMode == 0)
            {
                program[argument] = input;
            }
            else
            {
                int arg = program[argument];
                program[arg] = input;
            }
            return programPointer + 2;
        }

        private static int OutputValue(List<int> program, int programPointer, int firstParameterMode, int argument)
        {
            if (firstParameterMode == 0)
            {
                Console.Write(program[argument]);
            }
            else
            {
                Console.Write(argument);
            }
            return programPointer + 2;
        }

        private static int JumpIfTrue(List<int> program, int programPointer, int firstParameterMode, int secondParameterMode)
        {
            bool jump = false;
            if (firstParameterMode == 0)
            {
                int argument = program[++programPointer];
                if (program[argument] != 0)
                {
                    jump = true;
                }
            }
            else if (firstParameterMode == 1)
            {
                if (program[++programPointer] != 0)
                {
                    jump = true;
                }
            }

            if (jump)
            {
                if (secondParameterMode == 0)
                {
                    int argument = program[++programPointer];
                    programPointer = program[argument];
                }
                else if (secondParameterMode == 1)
                {
                    programPointer = program[++programPointer];
                }
            }
            else
            {
                programPointer += 2;
            }

            return programPointer;
        }

        private static int JumpIfFalse(List<int> program, int programPointer, int firstParameterMode, int secondParameterMode)
        {
            bool jump = false;
            if (firstParameterMode == 0)
            {
                int argument = program[++programPointer];
                if (program[argument] == 0)
                {
                    jump = true;
                }
            }
            else if (firstParameterMode == 1)
            {
                if (program[++programPointer] == 0)
                {
                    jump = true;
                }
            }

            if (jump)
            {
                if (secondParameterMode == 0)
                {
                    int argument = program[++programPointer];
                    programPointer = program[argument];
                }
                else if (secondParameterMode == 1)
                {
                    programPointer = program[++programPointer];
                }
            }
            else
            {
                programPointer += 2;
            }

            return programPointer;
        }

        private static int IsLessThan(List<int> program, int programPointer, int firstParameterMode, int secondParameterMode)
        {
            int firstParameterValue, secondParameterValue;

            if (firstParameterMode == 0)
            {
                int argument = program[++programPointer];
                firstParameterValue = program[argument];
            }
            else
            {
                firstParameterValue = program[++programPointer];
            }

            if (secondParameterMode == 0)
            {
                int argument = program[++programPointer];
                secondParameterValue = program[argument];
            }
            else
            {
                secondParameterValue = program[++programPointer];
            }

            int thirdParameter = program[++programPointer];
            if (firstParameterValue < secondParameterValue)
            {
                program[thirdParameter] = 1;
            }
            else
            {
                program[thirdParameter] = 0;
            }

            return ++programPointer;
        }

        private static int IsEqual(List<int> program, int programPointer, int firstParameterMode, int secondParameterMode)
        {
            int firstParameterValue = 0, secondParameterValue = 0;

            if (firstParameterMode == 0)
            {
                int argument = program[++programPointer];
                firstParameterValue = program[argument];
            }
            else
            {
                firstParameterValue = program[++programPointer];
            }

            if (secondParameterMode == 0)
            {
                int argument = program[++programPointer];
                secondParameterValue = program[argument];
            }
            else
            {
                secondParameterValue = program[++programPointer];
            }

            int thirdParameter = program[++programPointer];
            if (firstParameterValue == secondParameterValue)
            {
                program[thirdParameter] = 1;
            }
            else
            {
                program[thirdParameter] = 0;
            }

            return ++programPointer;
        }

        #region Opcodes
        public static int OpCode8(List<int> program, int programPointer, int firstParameterMode, int secondParameterMode)
        {
            return IsEqual(program, programPointer, firstParameterMode, secondParameterMode);
        }

        public static int OpCode7(List<int> program, int programPointer, int firstParameterMode, int secondParameterMode)
        {
            return IsLessThan(program, programPointer, firstParameterMode, secondParameterMode);
        }

        public static int OpCode6(List<int> program, int programPointer, int firstParameterMode, int secondParameterMode)
        {
            return JumpIfFalse(program, programPointer, firstParameterMode, secondParameterMode);
        }

        public static int OpCode5(List<int> program, int programPointer, int firstParameterMode, int secondParameterMode)
        {
            return JumpIfTrue(program, programPointer, firstParameterMode, secondParameterMode);
        }

        public static int OpCode4(List<int> program, int programPointer, int firstParameterMode, int argument)
        {
            return OutputValue(program, programPointer, firstParameterMode, argument);
        }

        public static int OpCode3(List<int> program, int programPointer, int firstParameterMode, int argument, int input)
        {
            return StoreValue(program, programPointer, firstParameterMode, argument, input);
        }

        public static int OpCode2(List<int> program, int programPointer, int firstParameterMode = 0, int secondParameterMode = 0)
        {
            return Multiply(program, programPointer, firstParameterMode, secondParameterMode);
        }

        public static int OpCode1(List<int> program, int programPointer, int firstParameterMode = 0, int secondParameterMode = 0)
        {
           return Add(program, programPointer, firstParameterMode, secondParameterMode);
        }
        #endregion

    }
}
