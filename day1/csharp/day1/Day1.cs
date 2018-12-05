using System;
using System.IO;
using System.Linq;

namespace day1
{
    class Day1
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\peter\Developer\advent-of-code-2018\day1\input.txt");
            Console.WriteLine($"Part 1: {Part1(lines)}");
            Console.ReadKey();
        }

        static int Part1(string[] input)
        {
            return input.Select(s => int.Parse(s)).Sum();
        }
    }
}
