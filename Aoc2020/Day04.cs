namespace AdventOfCode.Aoc2020
{
    public class Day04
    {
        private int _part;
        const string _path = "Aoc2020/Assets/day04_input.txt";
        string _input = File.ReadAllText(_path);
        public Day04(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var checkPassportsWithoutCid = CheckPassportsWithoutCid();

                return checkPassportsWithoutCid.ToString();
            }

            // if (_part == 2)
            // {

            //     var sumAllTreeThatGetHit = SumAllTreeThatGetHit();

            //     return sumAllTreeThatGetHit.ToString();
            // }

            return "invalid part";
        }

        public int CheckPassportsWithoutCid()
        {
            int counter = 0;
            int fieldcounter = 0;
            string[] requiredFields = new String[]
            {
                "ecl", "pid", "eyr", "byr", "hcl", "iyr", "hgt"
            };

            string[] splitedPassports = _input.Split(new string[] {Environment.NewLine + Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string passport in splitedPassports)
            {
                foreach (string field in requiredFields)
                {
                    if (passport.Contains(field))
                    {
                        fieldcounter++;
                    }
                }
                if (fieldcounter >= 7)
                {
                    counter++;
                }
                fieldcounter = 0;
            }

            return counter;
        }
    }
}