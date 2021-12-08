namespace AdventOfCode.Aoc2021
{
    using AdventOfCode.Aoc2021.Models;
    public class Day07
    {
        private int _part;
        private const string _path = "Aoc2021/Assets/day07_input.txt";
        private List<string> _file = File.ReadAllLines(_path).ToList();

        public Day07(int part)
        {
            _part = part;
        }

        public override string ToString()
        {
            if (_part == 1)
            {
                var result = GetFuelCosts();

                return result.ToString();
            }

            if (_part == 2)
            {
                var result = GetFuelCosts2();

                return result.ToString();
            }

            return "invalid part";
        }

        public int GetFuelCosts()
        {
            List<int> listOfCrabs = new List<int>((_file[0].Split(',').Select(m => int.Parse(m))));
            int highestCrab = 0;
            int fuel = 0;
            int sumOfFuel = 0;
            int cheapestFuelValue = 0;

            for (int i = 0; i < listOfCrabs.Count; i++)
            {
                if (highestCrab < listOfCrabs[i])
                {
                    highestCrab = listOfCrabs[i];
                }
            }

            for (int i = 1; i <= highestCrab; i++)
            {
                foreach (var crab in listOfCrabs)
                {
                    fuel = Math.Abs(crab - i);
                    sumOfFuel += fuel;
                }

                if (cheapestFuelValue == 0)
                {
                    cheapestFuelValue = sumOfFuel;
                }

                if (sumOfFuel < cheapestFuelValue)
                {
                    cheapestFuelValue = sumOfFuel;
                }

                sumOfFuel = 0;
            }

            return cheapestFuelValue;
        }

        public int GetFuelCosts2()
        {
            List<int> listOfCrabs = new List<int>((_file[0].Split(',').Select(m => int.Parse(m))));
            int highestCrab = 0;
            int fuel = 0;
            int fuelExtraCost = 0;
            int sumOfFuel = 0;
            int cheapestFuelValue = 0;

            for (int i = 0; i < listOfCrabs.Count; i++)
            {
                if (highestCrab < listOfCrabs[i])
                {
                    highestCrab = listOfCrabs[i];
                }
            }

            for (int i = 1; i <= highestCrab; i++)
            {
                foreach (var crab in listOfCrabs)
                {
                    fuel = Math.Abs(crab - i);
                    for (int j = 1; j <= fuel; j++)
                    {
                        fuelExtraCost += j;
                    }
                    sumOfFuel += fuelExtraCost;
                    fuelExtraCost = 0;
                }

                if (cheapestFuelValue == 0)
                {
                    cheapestFuelValue = sumOfFuel;
                }

                if (sumOfFuel < cheapestFuelValue)
                {
                    cheapestFuelValue = sumOfFuel;
                }

                sumOfFuel = 0;
                
            }

            return cheapestFuelValue;
        }
    }
}