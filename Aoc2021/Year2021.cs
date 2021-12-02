namespace AdventOfCode.Aoc2021
{
    using AdventOfCode.Helpers;
    public class Year2021
    {
        public void Run(int? day = null)
        {
            if (!day.HasValue || day == 1)
            {
                DoDay01();
            }

            if (!day.HasValue || day == 2)
            {
                DoDay02();
            }
        }

        private void DoDay01()
        {
            var day1 = new Day01(1);
            string part1 = day1.ToString();


            day1 = new Day01(2);
            string part2 = day1.ToString();

            OutputHelper.PrintDay(1, part1, part2);
        }

        private void DoDay02()
        {
            var day2 = new Day02(1);
            string part1 = day2.ToString();


            day2 = new Day02(2);
            string part2 = day2.ToString();

            OutputHelper.PrintDay(1, part1, part2);
        }
    }
}