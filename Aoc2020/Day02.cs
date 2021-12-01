namespace AdventOfCode.Aoc2020
{
    public class Day02
    {
        private int _part;
        const string _path = "Aoc2020/Assets/day02_input.txt";
        List<string> _lines = File.ReadAllLines(_path).ToList();
        public Day02(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var getAllCorrectPasswords = GetAllCorrectPasswords();

                return getAllCorrectPasswords.ToString();
            }

            if (_part == 2)
            {
                var getAllCorrectPasswordsPart2 = GetAllCorrectPasswordsPart2();

                return getAllCorrectPasswordsPart2.ToString();
            }

            return "invalid part";
        }

        public int GetAllCorrectPasswords()
        {
            int counter = 0;
            int SumOfChar = 0;
            foreach (string line in _lines)
            {
                string[] linesplit = line.Split(' ');
                string[] numbersplit = linesplit[0].Split('-');

                SumOfChar = line.Where(x => (x == linesplit[1][0])).Count() - 1;
                if (SumOfChar >= int.Parse(numbersplit[0]) && SumOfChar <= int.Parse(numbersplit[1]))
                {
                    counter++;
                }
            }
            return counter;
        }
        public int GetAllCorrectPasswordsPart2()
        {
            int counter = 0;
            foreach (string line in _lines)
            {
                string[] linesplit = line.Split(' ');
                string[] numbersplit = linesplit[0].Split('-');

                if (linesplit[1][0].Equals(linesplit[2][int.Parse(numbersplit[0]) - 1]) || linesplit[1][0].Equals(linesplit[2][int.Parse(numbersplit[1]) - 1]))
                {
                    if (!(linesplit[1][0].Equals(linesplit[2][int.Parse(numbersplit[0]) - 1]) && linesplit[1][0].Equals(linesplit[2][int.Parse(numbersplit[1]) - 1])))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
    }
}