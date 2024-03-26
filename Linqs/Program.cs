namespace Linqs
{
    public static class ArrayQueries
    {
        // Get an entire array of integers
        public static int[] GetArray(int[] array)
        {
            return array.ToArray();
        }

        // Get the even integers using LINQ query
        public static int[] GetEvenIntegers(int[] array)
        {
            var evenIntegers = from num in array
                               where num % 2 == 0
                               select num;
            return evenIntegers.ToArray();
        }

        // Get the odd integers using LINQ query
        public static int[] GetOddIntegers(int[] array)
        {
            var oddIntegers = from num in array
                              where num % 2 != 0
                              select num;
            return oddIntegers.ToArray();
        }

        // Get the values greater than the specified using LINQ query
        public static int[] GetValuesGreaterThan(int[] array, int threshold)
        {
            var valuesGreaterThanThreshold = from num in array
                                             where num > threshold
                                             select num;
            return valuesGreaterThanThreshold.ToArray();
        }

        // Get numbers in a specified range using LINQ query
        public static int[] GetNumbersInRange(int[] array, int min, int max)
        {
            var numbersInRange = from num in array
                                 where num >= min && num <= max
                                 select num;
            return numbersInRange.ToArray();
        }

        // Get numbers that are multiples of seven. Sort the result in ascending order using LINQ query
        public static int[] GetMultiplesOfSevenAscending(int[] array)
        {
            var multiplesOfSevenAscending = from num in array
                                            where num % 7 == 0
                                            orderby num ascending
                                            select num;
            return multiplesOfSevenAscending.ToArray();
        }

        // Get numbers that are multiples of eight. Sort the result in descending order using LINQ query
        public static int[] GetMultiplesOfEightDescending(int[] array)
        {
            var multiplesOfEightDescending = from num in array
                                             where num % 8 == 0
                                             orderby num descending
                                             select num;
            return multiplesOfEightDescending.ToArray();
        }
    }
    internal class Program
    {
        static void Main()
        {
            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 14, 16, 18, 21, 24, 28 };

            Console.WriteLine("Entire Array:");
            Console.WriteLine(string.Join(", ", ArrayQueries.GetArray(integers)));

            Console.WriteLine("\nEven Integers:");
            Console.WriteLine(string.Join(", ", ArrayQueries.GetEvenIntegers(integers)));

            Console.WriteLine("\nOdd Integers:");
            Console.WriteLine(string.Join(", ", ArrayQueries.GetOddIntegers(integers)));

            Console.WriteLine("\nValues Greater Than 10:");
            Console.WriteLine(string.Join(", ", ArrayQueries.GetValuesGreaterThan(integers, 10)));

            Console.WriteLine("\nNumbers in Range 5-15:");
            Console.WriteLine(string.Join(", ", ArrayQueries.GetNumbersInRange(integers, 5, 15)));

            Console.WriteLine("\nMultiples of Seven (Ascending Order):");
            Console.WriteLine(string.Join(", ", ArrayQueries.GetMultiplesOfSevenAscending(integers)));

            Console.WriteLine("\nMultiples of Eight (Descending Order):");
            Console.WriteLine(string.Join(", ", ArrayQueries.GetMultiplesOfEightDescending(integers)));
        }
    }
}
