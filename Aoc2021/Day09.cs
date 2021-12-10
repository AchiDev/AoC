using AdventOfCode.Aoc2021.Models;

namespace AdventOfCode.Aoc2021
{
    public class Day09
    {
        private int _part;
        private const string _path = "Aoc2021/Assets/day09_input.txt";
        List<string> _file = File.ReadAllLines(_path).ToList();

        public Day09(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var points = GetPointsWithLowestPointsMarked();
                int result = 0;

                foreach (var point in points)
                {
                    if (point.IsLowestPoint)
                    {
                        result += point.Value + 1;
                    }
                }

                return result.ToString();
            }

            if (_part == 2)
            {
                GetBasins();

                return "o";
            }

            return "invalid part";
        }

        public List<Point> GetPointsWithLowestPointsMarked()
        {
            List<Point> points = new List<Point>();
            string currentLine;

            for (int i = 0; i < _file.Count; i++)
            {
                for (int j = 0; j < _file[i].Length; j++)
                {
                    points.Add(new Point(x: j, y: i, value: int.Parse(_file[i][j].ToString())));
                }
            }

            for (int line = 0; line < _file.Count; line++)
            {
                currentLine = _file[line];
                if (line == 0)
                {
                    for (int i = 0; i < currentLine.Length; i++)
                    {

                        var edgeCheck = Point.CheckEdge(linePosition: i, lineLength: currentLine.Length);

                        if (edgeCheck.isEdge)
                        {
                            if (edgeCheck.direction == "left")
                            {
                                if (currentLine[i] < _file[line + 1][i] && currentLine[i] < currentLine[i + 1])
                                {
                                    points.Single(x => x.Y == line && x.X == i).IsLowestPoint = true;
                                }
                            }
                            else
                            {
                                if (currentLine[i] < _file[line + 1][i] && currentLine[i] < currentLine[i - 1])
                                {

                                    points.Single(x => x.Y == line && x.X == i).IsLowestPoint = true;
                                }
                            }
                        }
                        else
                        {
                            if (currentLine[i] < _file[line + 1][i] && currentLine[i] < currentLine[i - 1] && currentLine[i] < currentLine[i + 1])
                            {
                                points.Single(x => x.Y == line && x.X == i).IsLowestPoint = true;
                            }
                        }
                    }
                }
                else if (line == _file.Count - 1)
                {
                    for (int i = 0; i < currentLine.Length; i++)
                    {

                        var edgeCheck = Point.CheckEdge(linePosition: i, lineLength: currentLine.Length);

                        if (edgeCheck.isEdge)
                        {
                            if (edgeCheck.direction == "left")
                            {
                                if (currentLine[i] < _file[line - 1][i] && currentLine[i] < currentLine[i + 1])
                                {
                                    points.Single(x => x.Y == line && x.X == i).IsLowestPoint = true;
                                }
                            }
                            else
                            {
                                if (currentLine[i] < _file[line - 1][i] && currentLine[i] < currentLine[i - 1])
                                {
                                    points.Single(x => x.Y == line && x.X == i).IsLowestPoint = true;
                                }
                            }
                        }
                        else
                        {
                            if (currentLine[i] < _file[line - 1][i] && currentLine[i] < currentLine[i - 1] && currentLine[i] < currentLine[i + 1])
                            {
                                points.Single(x => x.Y == line && x.X == i).IsLowestPoint = true;
                            }
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < currentLine.Length; i++)
                    {

                        var edgeCheck = Point.CheckEdge(linePosition: i, lineLength: currentLine.Length);

                        if (edgeCheck.isEdge)
                        {
                            if (edgeCheck.direction == "left")
                            {
                                if (currentLine[i] < _file[line - 1][i] && currentLine[i] < _file[line + 1][i] && currentLine[i] < currentLine[i + 1])
                                {
                                    points.Single(x => x.Y == line && x.X == i).IsLowestPoint = true;
                                }
                            }
                            else
                            {
                                if (currentLine[i] < _file[line - 1][i] && currentLine[i] < _file[line + 1][i] && currentLine[i] < currentLine[i - 1])
                                {
                                    points.Single(x => x.Y == line && x.X == i).IsLowestPoint = true;
                                }
                            }
                        }
                        else
                        {
                            if (currentLine[i] < _file[line - 1][i] && currentLine[i] < _file[line + 1][i] && currentLine[i] < currentLine[i - 1] && currentLine[i] < currentLine[i + 1])
                            {
                                points.Single(x => x.Y == line && x.X == i).IsLowestPoint = true;
                            }
                        }
                    }
                }

            }

            return points;
        }

        public void GetBasins()
        {
            List<Point> points = GetPointsWithLowestPointsMarked();
            List<int> basins = new List<int>();

            foreach (var point in points.Where(point => point.IsLowestPoint == true))
            {
                point.IsMarked = true;

               // point
            }
        }

    }
}
