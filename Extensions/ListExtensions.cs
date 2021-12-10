namespace AdventOfCode.Extensions
{
    public static class ListExtensions
    {
        public static double GetMedian(this List<double> list)
        {
            var sortedList = new List<double>(list).OrderBy(m => m).ToList();
            int indexOfMiddle = sortedList.Count / 2;

            if (sortedList.Count % 2 == 0)
            {
                return (sortedList[indexOfMiddle] + sortedList[indexOfMiddle - 1]) / 2;
            }

            return sortedList[indexOfMiddle];
        }

        public static double GetMedian(this List<int> list)
        {
            var sortedList = new List<int>(list).OrderBy(m => m).ToList();
            int indexOfMiddle = sortedList.Count / 2;

            if (sortedList.Count % 2 == 0)
            {
                return (sortedList[indexOfMiddle] + sortedList[indexOfMiddle - 1]) / 2;
            }

            return sortedList[indexOfMiddle];
        }
    }
}