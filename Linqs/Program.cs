namespace Linqs
{

    public static class CityQueries
    {
        /// <summary>
        /// Get an entire array of cities.
        /// </summary>
        /// <param name="cities">Array of city names</param>
        /// <returns>Array of cities</returns>
        public static string[] GetAllCities(string[] cities)
        {
            return cities;
        }

        /// <summary>
        /// Get the cities with a name length equal to the specified one.
        /// </summary>
        /// <param name="cities">Array of city names</param>
        /// <param name="length">Specified length</param>
        /// <returns>Array of cities</returns>
        public static string[] GetCitiesByLength(string[] cities, int length)
        {
            return cities.Where(city => city.Length == length).ToArray();
        }

        /// <summary>
        /// Get the cities whose names start with the letter A.
        /// </summary>
        /// <param name="cities">Array of city names</param>
        /// <returns>Array of cities</returns>
        public static string[] GetCitiesStartWithA(string[] cities)
        {
            return cities.Where(city => city.StartsWith("A")).ToArray();
        }

        /// <summary>
        /// Get the cities that names finish with the letter M.
        /// </summary>
        /// <param name="cities">Array of city names</param>
        /// <returns>Array of cities</returns>
        public static string[] GetCitiesEndWithM(string[] cities)
        {
            return cities.Where(city => city.EndsWith("M")).ToArray();
        }

        /// <summary>
        /// Get the cities whose names start with the letter N and end with K.
        /// </summary>
        /// <param name="cities">Array of city names</param>
        /// <returns>Array of cities</returns>
        public static string[] GetCitiesStartWithNEndWithK(string[] cities)
        {
            return cities.Where(city => city.StartsWith("N") && city.EndsWith("K")).ToArray();
        }

        /// <summary>
        /// Get the cities whose names start with the string "Ne". Sort the result in descending order.
        /// </summary>
        /// <param name="cities">Array of city names</param>
        /// <returns>Array of cities</returns>
        public static string[] GetCitiesStartWithNeDescending(string[] cities)
        {
            return cities.Where(city => city.StartsWith("Ne")).OrderByDescending(city => city).ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] cities = { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego" };

            // Example usage of queries
            Console.WriteLine("All cities:");
            Console.WriteLine(string.Join(", ", CityQueries.GetAllCities(cities)));

            Console.WriteLine("\nCities with name length equal to 10:");
            Console.WriteLine(string.Join(", ", CityQueries.GetCitiesByLength(cities, 10)));

            Console.WriteLine("\nCities starting with 'A':");
            Console.WriteLine(string.Join(", ", CityQueries.GetCitiesStartWithA(cities)));

            Console.WriteLine("\nCities ending with 'M':");
            Console.WriteLine(string.Join(", ", CityQueries.GetCitiesEndWithM(cities)));

            Console.WriteLine("\nCities starting with 'N' and ending with 'K':");
            Console.WriteLine(string.Join(", ", CityQueries.GetCitiesStartWithNEndWithK(cities)));

            Console.WriteLine("\nCities starting with 'Ne' in descending order:");
            Console.WriteLine(string.Join(", ", CityQueries.GetCitiesStartWithNeDescending(cities)));
        }
    }
}
