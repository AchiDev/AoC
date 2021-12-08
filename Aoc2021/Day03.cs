namespace AdventOfCode.Aoc2021
{
    public class Day03
    {
        private int _part;
        private int _sumOfBinaryZeros;
        private int _sumOfBinaryOnes;
        private const string _path = "Aoc2021/Assets/day03_input.txt";
        private List<string> _lines = File.ReadAllLines(_path).ToList();

        public Day03(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var calculateGammaAndEpsilonRate = CalculateGammaAndEpsilonRate();

                return calculateGammaAndEpsilonRate.ToString();
            }

            if (_part == 2)
            {
                var co2 = CalculateCO2Rate();
                var oxygen = CalculateOxygenRate();

                return (co2 * oxygen).ToString();
            }

            return "invalid part";
        }

        public int CalculateGammaAndEpsilonRate()
        {
            _sumOfBinaryZeros = 0;
            _sumOfBinaryOnes = 0;
            int gammaHexa;
            int epsilonHexa;
            List<string> averageMostCommonNumber = new List<string>();
            List<string> averageLeastCommonNumber = new List<string>();

            for (int i = 0; i < _lines[0].Length; i++)
            {
                foreach (string line in _lines)
                {
                    if (line[i] == '0')
                    {
                        _sumOfBinaryZeros++;
                    }
                    else if (line[i] == '1')
                    {
                        _sumOfBinaryOnes++;
                    }

                }

                if (_sumOfBinaryZeros > _sumOfBinaryOnes)
                {
                    averageMostCommonNumber.Add("0");
                }
                else if (_sumOfBinaryOnes > _sumOfBinaryZeros)
                {
                    averageMostCommonNumber.Add("1");
                }

                if (_sumOfBinaryZeros < _sumOfBinaryOnes)
                {
                    averageLeastCommonNumber.Add("0");
                }
                else if (_sumOfBinaryOnes < _sumOfBinaryZeros)
                {
                    averageLeastCommonNumber.Add("1");
                }

                _sumOfBinaryZeros = 0;
                _sumOfBinaryOnes = 0;
            }

            gammaHexa = Convert.ToInt32((string.Join(null, averageLeastCommonNumber)), 2);
            epsilonHexa = Convert.ToInt32((string.Join(null, averageMostCommonNumber)), 2);

            return epsilonHexa * gammaHexa;
        }

        public int CalculateOxygenRate()
        {
            _sumOfBinaryZeros = 0;
            _sumOfBinaryOnes = 0;

            List<string> averageMostCommonNumber = new List<string>(_lines);

            for (int i = 0; i < averageMostCommonNumber[0].Length; i++)
            {
                if (averageMostCommonNumber.Count == 1)
                {
                    break;
                }
                foreach (string line in averageMostCommonNumber)
                {
                    if (line[i] == '0')
                    {
                        _sumOfBinaryZeros += 1;
                    }
                    else if (line[i] == '1')
                    {
                        _sumOfBinaryOnes += 1;
                    }
                }

                if (_sumOfBinaryZeros > _sumOfBinaryOnes)
                {
                    averageMostCommonNumber = averageMostCommonNumber.Where(m => m[i] == '0').ToList();
                }
                else if (_sumOfBinaryOnes >= _sumOfBinaryZeros)
                {
                    averageMostCommonNumber = averageMostCommonNumber.Where(m => m[i] == '1').ToList();
                }

                _sumOfBinaryZeros = 0;
                _sumOfBinaryOnes = 0;

            }
            return Convert.ToInt32(averageMostCommonNumber[0], 2);
        }

        public int CalculateCO2Rate()
        {
            _sumOfBinaryZeros = 0;
            _sumOfBinaryOnes = 0;

            List<string> averageLeastCommonNumber = new List<string>(_lines);

            for (int i = 0; i < averageLeastCommonNumber[0].Length; i++)
            {
                if (averageLeastCommonNumber.Count == 1)
                {
                    break;
                }
                foreach (string line in averageLeastCommonNumber)
                {
                    if (line[i] == '0')
                    {
                        _sumOfBinaryZeros += 1;
                    }
                    else if (line[i] == '1')
                    {
                        _sumOfBinaryOnes += 1;
                    }
                }

                if (_sumOfBinaryZeros <= _sumOfBinaryOnes)
                {
                    averageLeastCommonNumber = averageLeastCommonNumber.Where(m => m[i] == '0').ToList();
                }
                else if (_sumOfBinaryOnes < _sumOfBinaryZeros)
                {
                    averageLeastCommonNumber = averageLeastCommonNumber.Where(m => m[i] == '1').ToList();
                }

                _sumOfBinaryZeros = 0;
                _sumOfBinaryOnes = 0;

            }
            return Convert.ToInt32(averageLeastCommonNumber[0], 2);
        }
    }
}