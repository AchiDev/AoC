namespace AdventOfCode.Aoc2021
{
    public class Day02
    {
        private int _part;
        private const string _path = "Aoc2021/Assets/day02_input.txt";
        private List<string> _lines = File.ReadAllLines(_path).ToList();

        public Day02(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var calculateTheDepth = CalculateTheDepth();

                return calculateTheDepth.ToString();
            }

            if (_part == 2)
            {
                var calculateTheDepthWithAim = CalculateTheDepthWithAim();

                return calculateTheDepthWithAim.ToString();
            }

            return "invalid part";
        }

        public int CalculateTheDepth()
        {
            int depth = 0;
            int horizontalForward = 0;
            foreach (string line in _lines)
            {
                var linesplit = line.Split(' ');

                switch (linesplit[0])
                {
                    case "forward":
                        horizontalForward += int.Parse(linesplit[1]);
                        break;

                    case "up":
                        depth -= int.Parse(linesplit[1]);
                        break;

                    case "down":
                        depth += int.Parse(linesplit[1]);
                        break;
                }
            }

            return depth * horizontalForward;
        }

        public int CalculateTheDepthWithAim()
        {
            int depth = 0;
            int aim = 0;
            int horizontalForward = 0;
            foreach (string line in _lines)
            {
                var linesplit = line.Split(' ');

                switch (linesplit[0])
                {
                    case "forward":
                        horizontalForward += int.Parse(linesplit[1]);
                        depth += aim * int.Parse(linesplit[1]);
                        break;

                    case "up":
                        aim -= int.Parse(linesplit[1]);
                        break;

                    case "down":
                        aim += int.Parse(linesplit[1]);
                        break;
                }
            }

            return depth * horizontalForward;
        }

    }
}