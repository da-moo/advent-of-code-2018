using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day2
{
    class Day2
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\peter\Developer\advent-of-code-2018\day2\input.txt");
            Console.WriteLine($"Part 1: {Part1(lines)}");
            Console.ReadKey();
        }

        static int Part1(string[] input)
        {
            int doubleLetterCount = 0;
            int tripleLetterCount = 0;

            foreach(string boxId in input)
            {
                Dictionary<char, int> seenDict = new Dictionary<char, int>();
                foreach(char character in boxId)
                {
                    seenDict[character] = seenDict.GetValueOrDefault(character) + 1;
                }
                if (seenDict.Values.Contains(2)) doubleLetterCount++;
                if (seenDict.Values.Contains(3)) tripleLetterCount++;
            }

            return doubleLetterCount * tripleLetterCount;
        }
    }
}
