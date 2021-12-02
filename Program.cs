namespace AdventOfCode
{
    using AdventOfCode.Aoc2021;
    using AdventOfCode.Aoc2020;
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new List<string>()
                {
                    "eifach nüt"
                }.ToArray();
            }
            switch (args[0])
            {
                case "2020":
                default:
                    Console.WriteLine("Year 2020");
                    var year2020 = new Year2020();
                    year2020.Run();
                    break;

                case "2021":
                
                    Console.WriteLine("Year 2021");
                    var year2021 = new Year2021();
                    year2021.Run();
                    break;
            }
        }
    }
}