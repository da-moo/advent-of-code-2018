using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day1
{
    internal class Day1
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"input.txt");
            Console.WriteLine($"Part 1: {Part1(lines)}\nPart 2: {Part2(lines)}");
            Console.ReadKey();
        }

        private static int Part1(IEnumerable<string> input)
        {
            return input.Select(int.Parse).Sum();
        }

        private static int Part2(IEnumerable<string> input)
        {
            var frequencyChanges = input.Select(int.Parse);
            var seenFrequencyChanges = new HashSet<int>();
            var cumulative = 0;

            do
            {
                foreach (var frequencyChange in frequencyChanges)
                {
                    cumulative += frequencyChange;
                    if (seenFrequencyChanges.Contains(cumulative)) return cumulative;
                    seenFrequencyChanges.Add(cumulative);
                }
            } while (true);
        }
    }
}