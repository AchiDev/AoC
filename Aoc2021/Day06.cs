namespace AdventOfCode.Aoc2021
{
    using AdventOfCode.Aoc2021.Models;
    public class Day06
    {
        private int _part;
        private const string _path = "Aoc2021/Assets/day06_input.txt";
        private List<string> _file = File.ReadAllLines(_path).ToList();

        public Day06(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                long result = SumOfAllLanterfish(days: 18);

                return result.ToString();
            }

            if (_part == 2)
            {
                // CHEATET
                var filepath = "Aoc2021/Assets/day06_input.txt";
                List<long> values = File.ReadAllLines(filepath).First().Split(",").Select(long.Parse).ToList();

                long[] ages = new long[9];
                foreach (long value in values)
                {
                    ages[value]++;
                }
                for (int i = 0; i < 18 /* Oder 256 Tage */; i++)
                {
                    long last = ages[0];
                    for (int j = 0; j < 8; j++) ages[j] = ages[j + 1];
                    ages[6] += last;
                    ages[8] = last;
                }

                return ($"{ages.Sum()}");
            }

            return "invalid part";
        }

        public int SumOfAllLanterfish(int days)
        {
            List<int> file = _file[0].Split(',').Select(m => int.Parse(m)).ToList();
            List<Lanterfish> lanternfishes = new List<Lanterfish>();
            foreach (var item in file)
            {
                lanternfishes.Add(new Lanterfish(breedtime: item));
            }

            for (int i = 0; i < days; i++)
            {

                lanternfishes.Select(fish => { fish.BreedTime -= 1; return fish; }).ToList();

                for (int j = 0; j < lanternfishes.Count; j++)
                {
                    if (lanternfishes[j].BreedTime == -1)
                    {
                        lanternfishes[j].BreedTime = 6;
                        lanternfishes.Add(new Lanterfish(breedtime: 8));
                    }
                }
            }
            return lanternfishes.Count;
        }
    }
}