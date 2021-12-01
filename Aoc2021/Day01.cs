namespace AdventOfCode.Aoc2021
{
    public class Day01
    {
        private int _part;
        private const string _path = "Aoc2021/Assets/day01_input.txt";
        private List<int> _lines = File.ReadAllLines(_path).ToList().Select(m => int.Parse(m)).ToList();
        private int _count;
        
        public Day01(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var numberOfIncreasedMeasurements = CountMeasureIncreases();

                return numberOfIncreasedMeasurements.ToString();
            }

            if (_part == 2)
            {
                var numberOfIncreasedMeasurements = CountThreeMeasures();

                return numberOfIncreasedMeasurements.ToString();
            }

            return "invalid part";
        }
        public int CountMeasureIncreases()
        {     
            _count = 0;
            for (int i = 0; i < _lines.Count - 1 ; i++)
            {
                if (_lines[i] < _lines[i + 1])
                {
                    _count++;
                }
            }
            return _count;
        }

        public int CountThreeMeasures()
        {
            _count = 0;
            for (int i = 0; i < _lines.Count - 3 ; i++)
            {
                if ((_lines[i] + _lines[i + 1] + _lines[i + 2]) < (_lines[i + 1] + _lines[i + 2] + _lines[i + 3]))
                {
                    _count++;
                }
            }
           return _count;
        }
    }
}