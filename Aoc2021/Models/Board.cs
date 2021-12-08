namespace AdventOfCode.Aoc2021.Models
{
    public class Board
    {
        public string Bingoboard { get; set; }
        public List<BoardLine> BoardLines { get; set; } = new List<BoardLine>();
        public Board(string bingoboard)
        {
            Bingoboard = bingoboard;
            MakeBoardLines();
        }

        public void MakeBoardLines()
        {
            var lines = Bingoboard.Split("\r\n").ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                BoardLines.Add(new BoardLine(lines[i]));
            }

        }

    }

    public class Boards : List<Board>
    {
    }

    public class BoardLine
    {
        public string SingleBoardLine { get; set; }
        public List<BoardNumber> BoardNumbers { get; set; } = new List<BoardNumber>();
        public BoardLine(string singleLine)
        {
            SingleBoardLine = singleLine;
            DeklareBoardNumbers();
        }

        private void DeklareBoardNumbers()
        {
            List<string> lineNumbers = new List<string>();

            lineNumbers = SingleBoardLine.Split(' ').Where(m => m.Length != 0).ToList();

            for (int i = 0; i < lineNumbers.Count; i++)
            {
                BoardNumbers.Add(new BoardNumber(number: lineNumbers[i], marked: false));
            }
        }
    }

    public class BoardNumber
    {
        public string Number { get; set; }
        public bool isMarked { get; set; }
        public BoardNumber(string number, bool marked)
        {
            Number = number;
            isMarked = marked;
        }
    }




}