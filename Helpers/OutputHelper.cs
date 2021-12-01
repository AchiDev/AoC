namespace AdventOfCode.Helpers
{
    using System;
    using AdventOfCode.Extensions;

    public static class OutputHelper
    {
        public static void PrintDay(int nr, object solution1, object solution2)
        {
            Console.WriteLine($"=========");
            Console.WriteLine($"day {nr.ToMultipleDigitNumber(2)}:");
            Console.WriteLine($"part 1: {solution1}");
            Console.WriteLine($"part 2: {solution2}");
        }
    }
}