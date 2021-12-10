using AdventOfCode.Aoc2021.Models;
using AdventOfCode.Extensions;

namespace AdventOfCode.Aoc2021
{
    public class Day10
    {
        private int _part;
        private const string _path = "Aoc2021/Assets/day10_input.txt";
        List<string> _file = File.ReadAllLines(_path).ToList();

        public Day10(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var result = GetScore();

                return result.ToString();
            }

            if (_part == 2)
            {
                var result = GetMiddleScore();

                return result.ToString();
            }

            return "invalid part";
        }

        public int GetScore()
        {
            int score = 0;

            for (int i = 0; i < _file.Count; i++)
            {
                score += CheckForCoruptChunk(line: _file[i]);
            }

            return score;
        }

        public double GetMiddleScore()
        {
            double result = 0;
            double middleScore = 0;
            List<string> imcompleteLines = new List<string>();
            List<char> incompletClams = new List<char>();
            List<double> totalLinePoints = new List<double>();

            for (int i = 0; i < _file.Count; i++)
            {
                if (CheckIncompletLine(_file[i]))
                {
                    imcompleteLines.Add(_file[i]);
                }
            }

            for (int i = 0; i < imcompleteLines.Count; i++)
            {
                incompletClams = GetListOfIncompletClams(imcompleteLines[i]);
                incompletClams.Reverse();

                for (int j = 0; j < incompletClams.Count; j++)
                {
                    switch (incompletClams[j])
                    {
                        case '(':
                            middleScore = (middleScore * 5) + 1;
                            break;
                        case '[':
                            middleScore = (middleScore * 5) + 2;
                            break;
                        case '{':
                            middleScore = (middleScore * 5) + 3;
                            break;
                        case '<':
                            middleScore = (middleScore * 5) + 4;
                            break;
                    }
                }

                totalLinePoints.Add(middleScore);
                middleScore = 0;
            }

            foreach (var item in totalLinePoints)
            {
                Console.WriteLine(item);
            }

            result = totalLinePoints.GetMedian();
            return result;
        }


        public int CheckForCoruptChunk(string line)
        {
            int checkClam = 0;
            List<char> clams = new List<char>();

            for (int j = 0; j < line.Length; j++)
            {
                switch (line[j])
                {
                    case '(':
                        clams.Add('(');
                        break;
                    case ')':
                        checkClam = clams.LastIndexOf('(');
                        if (checkClam == -1 || clams.Last() != '(')
                        {
                            return 3;
                        }
                        else
                        {
                            clams.RemoveAt(clams.LastIndexOf('('));
                        }
                        break;
                    case '[':
                        clams.Add('[');
                        break;
                    case ']':
                        checkClam = clams.LastIndexOf('[');
                        if (checkClam == -1 || clams.Last() != '[')
                        {
                            return 57;
                        }
                        else
                        {
                            clams.RemoveAt(clams.LastIndexOf('['));
                        }
                        break;
                    case '{':
                        clams.Add('{');
                        break;
                    case '}':
                        checkClam = clams.LastIndexOf('{');
                        if (checkClam == -1 || clams.Last() != '{')
                        {
                            return 1197;
                        }
                        else
                        {
                            clams.RemoveAt(clams.LastIndexOf('{'));
                        }
                        break;
                    case '<':
                        clams.Add('<');
                        break;
                    case '>':
                        checkClam = clams.LastIndexOf('<');
                        if (checkClam == -1 || clams.Last() != '<')
                        {
                            return 25137;
                        }
                        else
                        {
                            clams.RemoveAt(clams.LastIndexOf('<'));
                        }
                        break;
                }
            }

            return 0;
        }

        public bool CheckIncompletLine(string line)
        {
            int checkClam = 0;
            List<char> clams = new List<char>();

            for (int j = 0; j < line.Length; j++)
            {
                switch (line[j])
                {
                    case '(':
                        clams.Add('(');
                        break;
                    case ')':
                        checkClam = clams.LastIndexOf('(');
                        if (checkClam == -1 || clams.Last() != '(')
                        {
                            return false;
                        }
                        else
                        {
                            clams.RemoveAt(clams.LastIndexOf('('));
                        }
                        break;
                    case '[':
                        clams.Add('[');
                        break;
                    case ']':
                        checkClam = clams.LastIndexOf('[');
                        if (checkClam == -1 || clams.Last() != '[')
                        {
                            return false;
                        }
                        else
                        {
                            clams.RemoveAt(clams.LastIndexOf('['));
                        }
                        break;
                    case '{':
                        clams.Add('{');
                        break;
                    case '}':
                        checkClam = clams.LastIndexOf('{');
                        if (checkClam == -1 || clams.Last() != '{')
                        {
                            return false;
                        }
                        else
                        {
                            clams.RemoveAt(clams.LastIndexOf('{'));
                        }
                        break;
                    case '<':
                        clams.Add('<');
                        break;
                    case '>':
                        checkClam = clams.LastIndexOf('<');
                        if (checkClam == -1 || clams.Last() != '<')
                        {
                            return false;
                        }
                        else
                        {
                            clams.RemoveAt(clams.LastIndexOf('<'));
                        }
                        break;
                }
            }

            return true;
        }

        public List<char> GetListOfIncompletClams(string line)
        {
            List<char> clams = new List<char>();

            for (int j = 0; j < line.Length; j++)
            {
                switch (line[j])
                {
                    case '(':
                        clams.Add('(');
                        break;
                    case ')':
                        clams.RemoveAt(clams.LastIndexOf('('));
                        break;
                    case '[':
                        clams.Add('[');
                        break;
                    case ']':

                        clams.RemoveAt(clams.LastIndexOf('['));
                        break;
                    case '{':
                        clams.Add('{');
                        break;
                    case '}':
                        clams.RemoveAt(clams.LastIndexOf('{'));
                        break;
                    case '<':
                        clams.Add('<');
                        break;
                    case '>':
                        clams.RemoveAt(clams.LastIndexOf('<'));
                        break;
                }
            }

            return clams;
        }

    }
}
