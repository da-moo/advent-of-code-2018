using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day2
{
    internal class Day2
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\Users\peter\Developer\advent-of-code-2018\day2\input.txt");
            Console.WriteLine($"Part 1: {Part1(lines)}\nPart 2: {Part2(lines)}");
            Console.ReadKey();
        }

        private static int Part1(IEnumerable<string> input)
        {
            var doubleLetterCount = 0;
            var tripleLetterCount = 0;

            foreach (var boxId in input)
            {
                var seenDict = new Dictionary<char, int>();
                foreach (var character in boxId) seenDict[character] = seenDict.GetValueOrDefault(character) + 1;
                if (seenDict.Values.Contains(2)) doubleLetterCount++;
                if (seenDict.Values.Contains(3)) tripleLetterCount++;
            }

            return doubleLetterCount * tripleLetterCount;
        }

        private static string Part2(IEnumerable<string> input)
        {
            var matchingBoxIDs = input
                .SelectMany((boxId1, i) => input
                    .Where((boxId2, j) => i > j)
                    .Select(boxId2 => Tuple.Create(boxId1, boxId2)))
                .Single(pair => HammingDistance(pair.Item1, pair.Item2) == 1);

            var indexOfMismatch = -1;

            for (var i = 0; i < matchingBoxIDs.Item1.Length; i++)
            {
                if (matchingBoxIDs.Item1[i] == matchingBoxIDs.Item2[i]) continue;
                indexOfMismatch = i;
                break;
            }

            var commonChars = string.Concat(matchingBoxIDs.Item1.Substring(0, indexOfMismatch),
                matchingBoxIDs.Item1.Substring(indexOfMismatch + 1));
            return commonChars;
        }

        private static int HammingDistance(string first, string second)
        {
            return first
                .Zip(second, (firstChar, secondChar) => new {firstChar, secondChar})
                .Count(tuple => tuple.firstChar != tuple.secondChar);
        }
    }
}