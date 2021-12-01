namespace AdventOfCode.Extensions
{
    public static class IntExtensions
    {
        public static string ToMultipleDigitNumber(this int number, int digits)
        {
            int numberOfDigits = number.ToString().Length;
            string result = number.ToString();

            while (result.Length < digits)
            {
                result = $"0{result}";
            }

            return result;
        }
    }
}