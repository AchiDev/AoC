namespace AdventOfCode.Aoc2020
{
    public class Day03
    {
        private int _part;
        const string _path = "Aoc2020/Assets/day03_input.txt";
        List<string> _lines = File.ReadAllLines(_path).ToList();
        public Day03(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var sumAllTreeThatGetHit = SumAllTreeThatGetHit();

                return sumAllTreeThatGetHit.ToString();
            }

            if (_part == 2)
            {

                double count1 = this.GetAllTreeThatGetHitWithAllSlopes(right: 1, down: 1);
                double count2 = this.GetAllTreeThatGetHitWithAllSlopes(right: 3, down: 1);
                double count3 = this.GetAllTreeThatGetHitWithAllSlopes(right: 5, down: 1);
                double count4 = this.GetAllTreeThatGetHitWithAllSlopes(right: 7, down: 1);
                double count5 = this.GetAllTreeThatGetHitWithAllSlopes(right: 1, down: 2);

                double multiplied = count1 * count2 * count3 * count4 * count5;

                return multiplied.ToString();
            }

            return "invalid part";
        }

        public int SumAllTreeThatGetHit()
        {
            int slideRight = 0;
            int counter = 0;

            foreach (string line in _lines)
            {

                if (line.Length <= slideRight)
                {
                    slideRight = slideRight - line.Length;
                }

                if (line[slideRight] == '#')
                {
                    counter++;
                }

                slideRight += 3;
            }

            return counter;

        }

        public int GetAllTreeThatGetHitWithAllSlopes(int right, int down)
        {
            int slideRight = 0;
            int counter = 0;

            // if (_lines[0][slideRight] == '#')
            // {
            //     counter++;
            // }   

            for (int outerCount = 0; outerCount < _lines.Count; outerCount += down)
            {
                

                if (_lines[outerCount].Length <= slideRight)
                {
                    slideRight -= _lines[outerCount].Length;
                }

                if (_lines[outerCount][slideRight] == '#')
                {
                    counter++;
                }

                slideRight += right;

            }

            return counter;
        }
    }
}