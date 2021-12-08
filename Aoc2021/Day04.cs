namespace AdventOfCode.Aoc2021
{
    using AdventOfCode.Aoc2021.Models;
    public class Day04
    {
        private int _part;
        private const string _path = "Aoc2021/Assets/day04_input.txt";
        private string _file = File.ReadAllText(_path);

        public Day04(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var result = PickTheWinnerBoard();

                return result.ToString();
            }

            if (_part == 2)
            {
                var result = PickTheLoserBoard();

                return result.ToString();
            }

            return "invalid part";
        }

        public int PickTheWinnerBoard()
        {
            string[] boards = _file.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] drawnNumbers = boards[0].Split(',');
            boards = boards.Where(m => !m.Contains(',')).ToArray();
            int notMarkedNumbers;

            var listOfBoards = new Boards();

            for (int i = 0; i < boards.Length; i++)
            {
                listOfBoards.Add(new Board(bingoboard: boards[i]));
            }

            foreach (var drawnNumber in drawnNumbers)
            {
                listOfBoards.SelectMany(board => board.BoardLines).SelectMany(line => line.BoardNumbers).Where(number => number.Number == drawnNumber).ToList().ForEach(number => number.isMarked = true);
                foreach (var board in listOfBoards)
                {
                    for (int column = 0; column < board.BoardLines[0].BoardNumbers.Count; column++)
                    {
                        for (int line = 0; line < board.BoardLines.Count; line++)
                        {
                            if (!board.BoardLines[line].BoardNumbers[column].isMarked)
                            {
                                break;
                            }
                            if (line == board.BoardLines.Count - 1)
                            {
                                notMarkedNumbers = int.Parse(drawnNumber) * board.BoardLines.SelectMany(line => line.BoardNumbers).Where(number => !number.isMarked).Sum(number => int.Parse(number.Number));
                                return notMarkedNumbers;
                            }
                        }
                    }
                    if (board.BoardLines.Select(line => line.BoardNumbers).Any(number => number.All(m => m.isMarked)))
                    {
                        notMarkedNumbers = int.Parse(drawnNumber) * board.BoardLines.SelectMany(line => line.BoardNumbers).Where(number => !number.isMarked).Sum(number => int.Parse(number.Number));
                        return notMarkedNumbers;
                    }
                }
            }

            return 0;
        }

        public int PickTheLoserBoard()
        {
            string[] boards = _file.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string[] drawnNumbers = boards[0].Split(',');
            boards = boards.Where(m => !m.Contains(',')).ToArray();
            int notMarkedNumbers;
            int counter = 0;

            var listOfBoards = new Boards();

            for (int i = 0; i < boards.Length; i++)
            {
                listOfBoards.Add(new Board(bingoboard: boards[i]));
            }

            foreach (var drawnNumber in drawnNumbers)
            {
                listOfBoards.SelectMany(board => board.BoardLines).SelectMany(line => line.BoardNumbers).Where(number => number.Number == drawnNumber).ToList().ForEach(number => number.isMarked = true);
                for (int i = 0; i < listOfBoards.Count; i++)
                {
                    for (int column = 0; column < listOfBoards[i].BoardLines[0].BoardNumbers.Count; column++)
                    {
                        for (int line = 0; line < listOfBoards[i].BoardLines.Count; line++)
                        {
                            if (!listOfBoards[i].BoardLines[line].BoardNumbers[column].isMarked)
                            {
                                break;
                            }
                            if (line == listOfBoards[i].BoardLines.Count - 1)
                            {
                              counter++;
                            }
                        }
                    }

                    if (listOfBoards[i].BoardLines.Select(line => line.BoardNumbers).Any(number => number.All(m => m.isMarked)))
                    {
                        counter++;
                    }

                    if (listOfBoards.Count == counter - 2)
                    {
                        notMarkedNumbers = int.Parse(drawnNumber) * listOfBoards[i].BoardLines.SelectMany(line => line.BoardNumbers).Where(number => !number.isMarked).Sum(number => int.Parse(number.Number));
                        return notMarkedNumbers;
                    }



                }
            }
            return 0;
        }
    }
}