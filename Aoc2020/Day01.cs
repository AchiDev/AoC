namespace AdventOfCode.Aoc2020
{
    public class Day01
    {
        private int _part;
        public Day01(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var numberOfIncreasedMeasurements = Method01();

                return numberOfIncreasedMeasurements.ToString();
            }

            // if (_part == 2)
            // {
            //     var numberOfIncreasedMeasurements = CountThreeMeasures();

            //     return numberOfIncreasedMeasurements.ToString();
            // }

            return "invalid part";
        }
        public string Method01()
        {
            string blubb =  "GUGÜÜÜSELI";

            return blubb;
        }
    }
}