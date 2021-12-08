namespace AdventOfCode.Aoc2021
{
    public class Day08
    {
        private int _part;
        private const string _path = "Aoc2021/Assets/day08_input.txt";
        List<string> _file = File.ReadAllLines(_path).ToList();

        public Day08(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var result = GetSpecificNumbers();

                return result.ToString();
            }

            if (_part == 2)
            {
                var result = GetSumOfPatterns();

                return result.ToString();
            }

            return "invalid part";
        }

        public int GetSpecificNumbers()
        {
            int counter = 0;

            foreach (var line in _file)
            {
                string[] parts = line.Split(" | ");
                string[] resultpatterns = parts[1].Split(" ");

                foreach (var pattern in resultpatterns)
                {
                    if (pattern.Length == 2 || pattern.Length == 3 || pattern.Length == 4 || pattern.Length == 7)
                    {
                        counter++;
                    }
                }

            }

            return counter;
        }

        public int GetSumOfPatterns()
        {
            int result = 0;

            foreach (var line in _file)
            {
                string patternresult = "";
                string[] parts = line.Split(" | ");
                string[] resultpatterns = parts[1].Split(" ");
                for (int i = 0; i < resultpatterns.Length; i++)
                {
                    char[] characters = resultpatterns[i].ToArray();
                    Array.Sort(characters);
                    resultpatterns[i] = new string(characters);
                }
                string[] allpatterns = line.Split(" ").OrderBy(m => m.Length).ToArray();
                for (int i = 0; i < allpatterns.Length; i++)
                {
                    char[] characters = allpatterns[i].ToArray();
                    Array.Sort(characters);
                    allpatterns[i] = new string(characters);
                }
                string[] numbers = new string[10];

                foreach (var pattern in allpatterns)
                {
                    switch (pattern.Length)
                    {
                        case 2:
                            numbers[1] = pattern;
                            break;
                        case 3:
                            numbers[7] = pattern;
                            break;
                        case 4:
                            numbers[4] = pattern;
                            break;
                        case 7:
                            numbers[8] = pattern;
                            break;
                    }

                    if (pattern.Length == 5)
                    {
                        //3
                        if (numbers[7].All(m => pattern.Contains(m)))
                        {
                            numbers[3] = pattern;
                        }
                        //5
                        else if (pattern.Count(m => numbers[4].Contains(m)) == 3)
                        {
                            numbers[5] = pattern;
                        }
                        //2
                        else
                        {
                            numbers[2] = pattern;
                        }
                    }
                    else if (pattern.Length == 6)
                    {
                        //9
                        if (numbers[4].All(m => pattern.Contains(m)))
                        {
                            numbers[9] = pattern;
                        }
                        //0
                        else if (numbers[7].All(m => pattern.Contains(m)))
                        {
                            numbers[0] = pattern;
                        }
                        //6
                        else
                        {
                            numbers[6] = pattern;
                        }
                    }
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.WriteLine($"{i}: {numbers[i]}");
                }

                foreach (var pattern in resultpatterns)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (pattern.Equals(numbers[i]))
                        {
                            patternresult += $"{i}";
                        }
                    }
                }
                result += int.Parse(patternresult);
                patternresult = "";
            }

            return result;
        }
    }
}
