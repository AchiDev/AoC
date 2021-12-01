namespace AdventOfCode.Aoc2020
{
    public class Day01
    {
        private int _part;
        const string _path = "Aoc2020/Assets/day01_input.txt";
        List<int> _lines = File.ReadAllLines(_path).ToList().Select(m => int.Parse(m)).ToList();
        public Day01(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var getMultiplierOfTwoEntriesThatSum2020 = GetMultiplierOfTwoEntriesThatSum2020();

                return getMultiplierOfTwoEntriesThatSum2020.ToString();
            }

            if (_part == 2)
            {
                var getMultiplierOfThreeEntriesThatSum2020 = GetMultiplierOfThreeEntriesThatSum2020();

                return getMultiplierOfThreeEntriesThatSum2020.ToString();
            }

            return "invalid part";
        }
        public int GetMultiplierOfTwoEntriesThatSum2020()
        {
            int firstnumber = 0;
            int secondnumber = 0;


            for (int outercount = 0; outercount < _lines.Count; outercount++)
            {
                for (int innercount = 0; innercount < _lines.Count; innercount++)
                {
                    if ((_lines[outercount] + _lines[innercount] == 2020))
                    {
                        firstnumber = _lines[outercount];
                        secondnumber = _lines[innercount];
                    }
                }
            }

            return firstnumber * secondnumber;
        }

        public int GetMultiplierOfThreeEntriesThatSum2020()
        {
            int firstnumber = 0;
            int secondnumber = 0;
            int thirdnumber = 0;

            for (int counter1 = 0; counter1 < _lines.Count; counter1++)
            {
                for (int counter2 = 0; counter2 < _lines.Count; counter2++)
                {
                    for (int counter3 = 0; counter3 < _lines.Count; counter3++)
                    {
                        if ((_lines[counter1] + _lines[counter2] + _lines[counter3] == 2020))
                        {
                            firstnumber = _lines[counter1];
                            secondnumber = _lines[counter2];
                            thirdnumber = _lines[counter3];
                        }
                    }
                }
            }

            return firstnumber * secondnumber * thirdnumber;
        }
    }
}