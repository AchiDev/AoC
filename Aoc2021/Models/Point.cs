namespace AdventOfCode.Aoc2021.Models
{
    public class Point
    {

        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }
        public bool IsLowestPoint { get; set; }
        public bool IsMarked { get; set; }

        public Point(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
            IsLowestPoint = false;
            IsMarked = false;
        }

        public static (bool isEdge, string direction) CheckEdge(int linePosition, int lineLength)
        {

            if (linePosition == 0)
            {
                return (isEdge: true, direction: "left");
            }
            else if (linePosition + 1 == lineLength)
            {
                return (isEdge: true, direction: "right");
            }

            return (isEdge: false, direction: "");
        }
    }
}