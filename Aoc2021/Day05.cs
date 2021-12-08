namespace AdventOfCode.Aoc2021
{
    using AdventOfCode.Aoc2021.Models;
    public class Day05
    {
        private int _part;
        private const string _path = "Aoc2021/Assets/day05_input.txt";
        private List<string> _file = File.ReadAllLines(_path).ToList();

        public Day05(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var result = GetAllVents();

                return result.ToString();
            }

            if (_part == 2)
            {
                var result = GetAllVents2();

                return result.ToString();
            }

            return "invalid part";
        }


        public int GetAllVents()
        {
            List<string> coords = new List<string>();

            foreach (var line in _file)
            {
                string[] parts = line.Split(" -> ");
                string[] firstCoordinates = parts[0].Split(',');
                string[] secondCoordinates = parts[1].Split(',');

                int x1 = int.Parse(firstCoordinates[0]);
                int y1 = int.Parse(firstCoordinates[1]);
                int x2 = int.Parse(secondCoordinates[0]);
                int y2 = int.Parse(secondCoordinates[1]);

                if (x1 == x2)
                {
                    if (y1 > y2)
                    {
                        int absVal = Math.Abs(y1 - y2);
                        for (int i = 0; i < absVal + 1; i++)
                        {
                            coords.Add($"{x1},{y2 + i}");
                        }
                    }
                    else if (y1 < y2)
                    {
                        int absVal = Math.Abs(y2 - y1);
                        for (int i = 0; i < absVal + 1; i++)
                        {
                            coords.Add($"{x2},{y1 + i}");
                        }
                    }

                }
                else if (y1 == y2)
                {
                    if (x1 > x2)
                    {
                        int absVal = Math.Abs(x1 - x2);
                        for (int i = 0; i < absVal + 1; i++)
                        {
                            coords.Add($"{x2 + i},{y1}");
                        }
                    }
                    else if (x1 < x2)
                    {
                        int absVal = Math.Abs(x2 - x1);
                        for (int i = 0; i < absVal + 1; i++)
                        {
                            coords.Add($"{x1 + i},{y2}");
                        }
                    }
                }
            }

            var sortedList = coords.GroupBy(m => m).Where(g => g.Count() > 1).Select(c => c).ToList().Count;

            return sortedList;
        }

        public int GetAllVents2()
        {
            List<string> coords = new List<string>();

            foreach (var line in _file)
            {
                string[] parts = line.Split(" -> ");
                string[] firstCoordinates = parts[0].Split(',');
                string[] secondCoordinates = parts[1].Split(',');

                int x1 = int.Parse(firstCoordinates[0]);
                int y1 = int.Parse(firstCoordinates[1]);
                int x2 = int.Parse(secondCoordinates[0]);
                int y2 = int.Parse(secondCoordinates[1]);

                if (x1 == x2)
                {
                    if (y1 > y2)
                    {
                        int absVal = Math.Abs(y1 - y2);
                        for (int i = 0; i < absVal + 1; i++)
                        {
                            coords.Add($"{x1},{y2 + i}");
                        }
                    }
                    else if (y1 < y2)
                    {
                        int absVal = Math.Abs(y2 - y1);
                        for (int i = 0; i < absVal + 1; i++)
                        {
                            coords.Add($"{x2},{y1 + i}");
                        }
                    }

                }
                else if (y1 == y2)
                {
                    if (x1 > x2)
                    {
                        int absVal = Math.Abs(x1 - x2);
                        for (int i = 0; i < absVal + 1; i++)
                        {
                            coords.Add($"{x2 + i},{y1}");
                        }
                    }
                    else if (x1 < x2)
                    {
                        int absVal = Math.Abs(x2 - x1);
                        for (int i = 0; i < absVal + 1; i++)
                        {
                            coords.Add($"{x1 + i},{y2}");
                        }
                    }
                }
                else
                {
                    if (x1 > x2)
                    {
                        if (y1 > y2)
                        {
                            int absVal = Math.Abs(x1 - x2);
                            for (int i = 0; i < absVal + 1; i++)
                            {
                                coords.Add($"{x2 + i},{y2 + i}");
                            }
                        }
                        else
                        {
                            int absVal = Math.Abs(x1 - x2);
                            for (int i = 0; i < absVal + 1; i++)
                            {
                                coords.Add($"{x2 + i},{y2 - i}");
                            }
                        }

                    }
                    else if (x1 < x2)
                    {
                        if (y1 > y2)
                        {
                            int absVal = Math.Abs(x2 - x1);
                            for (int i = 0; i < absVal + 1; i++)
                            {
                                coords.Add($"{x1 + i},{y1 - i}");
                            }
                        }
                        else
                        {
                            int absVal = Math.Abs(x2 - x1);
                            for (int i = 0; i < absVal + 1; i++)
                            {
                                coords.Add($"{x1 + i},{y1 + i}");
                            }
                        }

                    }
                }

            }

            var sortedList = coords.GroupBy(m => m).Where(g => g.Count() > 1).Select(c => c).ToList().Count;

            return sortedList;
        }

    }
}