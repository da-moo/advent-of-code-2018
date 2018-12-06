using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day1
{
    class Day1
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"input.txt");
            Console.WriteLine($"Part 1: {Part1(lines)}\nPart 2: {Part2(lines)}");
            Console.ReadKey();
        }

        static int Part1(string[] input)
        {
            return input.Select(int.Parse).Sum();
        }

        static int Part2(string[] input)
        {
            var frequencyChanges = input.Select(int.Parse);
            HashSet<int> seenFrequencyChanges = new HashSet<int>();
            int cumulative = 0;

            do
            {
                foreach (int frequencyChange in frequencyChanges)
                {
                    cumulative += frequencyChange;
                    if (seenFrequencyChanges.Contains(cumulative))
                    {
                        return cumulative;
                    }
                    seenFrequencyChanges.Add(cumulative);
                }
            } while (true);
        }
    }
}
