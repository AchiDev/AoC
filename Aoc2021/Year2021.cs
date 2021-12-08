namespace AdventOfCode.Aoc2021
{
    using AdventOfCode.Helpers;
    public class Year2021
    {
        public void Run(int? day = 4)
        {
            if (!day.HasValue || day == 1)
            {
                DoDay01();
            }

            if (!day.HasValue || day == 2)
            {
                DoDay02();
            }

            if (!day.HasValue || day == 3)
            {
                DoDay03();
            }

            if (!day.HasValue || day == 4)
            {
                DoDay04();
            }

            if (!day.HasValue || day == 5)
            {
                DoDay05();
            }

            if (!day.HasValue || day == 6)
            {
                DoDay06();
            }

            if (!day.HasValue || day == 7)
            {
                DoDay07();
            }

            if (!day.HasValue || day == 8)
            {
                DoDay08();
            }
        }

        private void DoDay01()
        {
            var day = new Day01(1);
            string part1 = day.ToString();


            day = new Day01(2);
            string part2 = day.ToString();

            OutputHelper.PrintDay(1, part1, part2);
        }

        private void DoDay02()
        {
            var day = new Day02(1);
            string part1 = day.ToString();


            day = new Day02(2);
            string part2 = day.ToString();

            OutputHelper.PrintDay(2, part1, part2);
        }

        private void DoDay03()
        {
            var day = new Day03(1);
            string part1 = day.ToString();


            day = new Day03(2);
            string part2 = day.ToString();

            OutputHelper.PrintDay(3, part1, part2);
        }

        private void DoDay04()
        {
            var day = new Day04(1);
            string part1 = day.ToString();


            day = new Day04(2);
            string part2 = day.ToString() + " Falsch!!!!";

            OutputHelper.PrintDay(4, part1, part2);
        }

        private void DoDay05()
        {
            var day = new Day05(1);
            string part1 = day.ToString();


            day = new Day05(2);
            string part2 = day.ToString();

            OutputHelper.PrintDay(5, part1, part2);
        }

        private void DoDay06()
        {
            var day = new Day06(1);
            string part1 = day.ToString();


            day = new Day06(2);
            string part2 = day.ToString();

            OutputHelper.PrintDay(6, part1, part2);
        }

        private void DoDay07()
        {
            var day = new Day07(1);
            string part1 = day.ToString();


            day = new Day07(2);
            string part2 = day.ToString();

            OutputHelper.PrintDay(7, part1, part2);
        }

        private void DoDay08()
        {
            var day = new Day08(1);
            string part1 = day.ToString();


            day = new Day08(2);
            string part2 = day.ToString();

            OutputHelper.PrintDay(8, part1, part2);
        }
    }
}