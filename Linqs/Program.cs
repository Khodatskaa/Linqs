namespace Linqs
{

    public static class IntegerQueries
    {
        /// <summary>
        /// Get an entire array of integers.
        /// </summary>
        /// <param name="numbers">Array of integers</param>
        /// <returns>Array of integers</returns>
        public static int[] GetAllIntegers(int[] numbers)
        {
            return numbers;
        }

        /// <summary>
        /// Get the even integers.
        /// </summary>
        /// <param name="numbers">Array of integers</param>
        /// <returns>Array of even integers</returns>
        public static int[] GetEvenIntegers(int[] numbers)
        {
            return numbers.Where(n => n % 2 == 0).ToArray();
        }

        /// <summary>
        /// Get the odd integers.
        /// </summary>
        /// <param name="numbers">Array of integers</param>
        /// <returns>Array of odd integers</returns>
        public static int[] GetOddIntegers(int[] numbers)
        {
            return numbers.Where(n => n % 2 != 0).ToArray();
        }

        /// <summary>
        /// Get the values greater than the specified.
        /// </summary>
        /// <param name="numbers">Array of integers</param>
        /// <param name="specified">Specified value</param>
        /// <returns>Array of integers greater than the specified value</returns>
        public static int[] GetValuesGreaterThan(int[] numbers, int specified)
        {
            return numbers.Where(n => n > specified).ToArray();
        }

        /// <summary>
        /// Get numbers in a specified range.
        /// </summary>
        /// <param name="numbers">Array of integers</param>
        /// <param name="min">Minimum value of the range</param>
        /// <param name="max">Maximum value of the range</param>
        /// <returns>Array of integers within the specified range</returns>
        public static int[] GetNumbersInRange(int[] numbers, int min, int max)
        {
            return numbers.Where(n => n >= min && n <= max).ToArray();
        }

        /// <summary>
        /// Get numbers that are multiples of seven. Sort the result in ascending order.
        /// </summary>
        /// <param name="numbers">Array of integers</param>
        /// <returns>Array of integers that are multiples of seven</returns>
        public static int[] GetMultiplesOfSevenAscending(int[] numbers)
        {
            return numbers.Where(n => n % 7 == 0).OrderBy(n => n).ToArray();
        }

        /// <summary>
        /// Get numbers that are multiples of eight. Sort the result in descending order.
        /// </summary>
        /// <param name="numbers">Array of integers</param>
        /// <returns>Array of integers that are multiples of eight</returns>
        public static int[] GetMultiplesOfEightDescending(int[] numbers)
        {
            return numbers.Where(n => n % 8 == 0).OrderByDescending(n => n).ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 14, 16, 21, 24, 28, 35, 40 };

            // Example usage of queries
            Console.WriteLine("All integers:");
            Console.WriteLine(string.Join(", ", IntegerQueries.GetAllIntegers(numbers)));

            Console.WriteLine("\nEven integers:");
            Console.WriteLine(string.Join(", ", IntegerQueries.GetEvenIntegers(numbers)));

            Console.WriteLine("\nOdd integers:");
            Console.WriteLine(string.Join(", ", IntegerQueries.GetOddIntegers(numbers)));

            Console.WriteLine("\nValues greater than 10:");
            Console.WriteLine(string.Join(", ", IntegerQueries.GetValuesGreaterThan(numbers, 10)));

            Console.WriteLine("\nNumbers in the range 10 to 20:");
            Console.WriteLine(string.Join(", ", IntegerQueries.GetNumbersInRange(numbers, 10, 20)));

            Console.WriteLine("\nMultiples of seven in ascending order:");
            Console.WriteLine(string.Join(", ", IntegerQueries.GetMultiplesOfSevenAscending(numbers)));

            Console.WriteLine("\nMultiples of eight in descending order:");
            Console.WriteLine(string.Join(", ", IntegerQueries.GetMultiplesOfEightDescending(numbers)));
        }
    }

}
