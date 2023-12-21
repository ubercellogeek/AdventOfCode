using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day5
{
    public static class Part2
    {
        public static void Run()
        {
            var lines = File.ReadAllLines(Path.Combine("data","input.txt"));
            var groups = new List<List<long[]>>();

            var minval = long.MaxValue;

            var seeds = lines[0].Split("seeds: ")[1].Split(' ').Select(x => Convert.ToInt64(x)).ToList();

            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Contains("map"))
                {
                    groups.Add(new List<long[]>());
                }
                else if (string.IsNullOrEmpty(lines[i].Trim()))
                {

                }
                else
                {
                    var nums = lines[i].Split(' ').Select(x => Convert.ToInt64(x)).ToArray();

                    groups.Last().Add(nums);
                }
            }

            var locs = new List<long>();

            for (int i = 0; i < seeds.Count; i += 2)
            {
                Console.WriteLine($"{seeds[i]}, {seeds[i + 1]}");

                Parallel.For(seeds[i], seeds[i + 1] + seeds[i], (j) =>
                {
                    var val = j;
                    for (int xi = 0; xi < groups.Count; xi++)
                    {
                        val = groups[xi].GetDestinationValueFromArray(val).Item1;
                    }

                    if (val < minval)
                    {
                        minval = val;
                    }
                });
            }

            Console.WriteLine($"Min => {minval}");
        }
    }
}