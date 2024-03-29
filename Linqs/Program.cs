namespace Linqs
{
    /// <summary>
    /// Represents information about a company.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// The name of the company.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// The date the company was founded.
        /// </summary>
        public DateTime DateOfFoundation { get; set; }

        /// <summary>
        /// The business profile of the company (e.g., marketing, IT).
        /// </summary>
        public required string BusinessProfile { get; set; }

        /// <summary>
        /// The full name of the director of the company.
        /// </summary>
        public required string DirectorFullName { get; set; }

        /// <summary>
        /// The number of employees in the company.
        /// </summary>
        public int NumberOfEmployees { get; set; }

        /// <summary>
        /// The address of the company.
        /// </summary>
        public required string Address { get; set; }
    }

    /// <summary>
    /// Extension methods for querying collections of <see cref="Company"/> objects.
    /// </summary>
    public static class CompanyExtensions
    {
        /// <summary>
        /// Retrieves companies with a specified keyword in their titles.
        /// </summary>
        /// <param name="companies">The collection of companies to search.</param>
        /// <param name="keyword">The keyword to search for.</param>
        /// <returns>A collection of companies with the specified keyword in their titles.</returns>
        public static IEnumerable<Company> WithKeywordInTitle(this IEnumerable<Company> companies, string keyword)
        {
            return companies.Where(c => c.Name.Contains(keyword));
        }

        /// <summary>
        /// Retrieves companies in the marketing field.
        /// </summary>
        /// <param name="companies">The collection of companies to search.</param>
        /// <returns>A collection of companies in the marketing field.</returns>
        public static IEnumerable<Company> InMarketing(this IEnumerable<Company> companies)
        {
            return companies.Where(c => c.BusinessProfile.ToLower() == "marketing");
        }

        /// <summary>
        /// Retrieves companies in the marketing or IT fields.
        /// </summary>
        /// <param name="companies">The collection of companies to search.</param>
        /// <returns>A collection of companies in the marketing or IT fields.</returns>
        public static IEnumerable<Company> InMarketingOrIT(this IEnumerable<Company> companies)
        {
            return companies.Where(c => c.BusinessProfile.ToLower() == "marketing" || c.BusinessProfile.ToLower() == "it");
        }

        /// <summary>
        /// Retrieves companies with more than 100 employees.
        /// </summary>
        /// <param name="companies">The collection of companies to search.</param>
        /// <returns>A collection of companies with more than 100 employees.</returns>
        public static IEnumerable<Company> WithMoreThan100Employees(this IEnumerable<Company> companies)
        {
            return companies.Where(c => c.NumberOfEmployees > 100);
        }

        /// <summary>
        /// Retrieves companies with a specified range of employees.
        /// </summary>
        /// <param name="companies">The collection of companies to search.</param>
        /// <param name="minEmployees">The minimum number of employees.</param>
        /// <param name="maxEmployees">The maximum number of employees.</param>
        /// <returns>A collection of companies within the specified range of employees.</returns>
        public static IEnumerable<Company> WithEmployeesInRange(this IEnumerable<Company> companies, int minEmployees, int maxEmployees)
        {
            return companies.Where(c => c.NumberOfEmployees >= minEmployees && c.NumberOfEmployees <= maxEmployees);
        }

        /// <summary>
        /// Retrieves companies based in a specified city.
        /// </summary>
        /// <param name="companies">The collection of companies to search.</param>
        /// <param name="city">The city to search for.</param>
        /// <returns>A collection of companies based in the specified city.</returns>
        public static IEnumerable<Company> BasedIn(this IEnumerable<Company> companies, string city)
        {
            return companies.Where(c => c.Address.ToLower().Contains(city.ToLower()));
        }

        /// <summary>
        /// Retrieves companies with a specified director's last name.
        /// </summary>
        /// <param name="companies">The collection of companies to search.</param>
        /// <param name="lastName">The last name of the director.</param>
        /// <returns>A collection of companies with the specified director's last name.</returns>
        public static IEnumerable<Company> WithDirectorLastName(this IEnumerable<Company> companies, string lastName)
        {
            return companies.Where(c => c.DirectorFullName.Split(' ').Last().ToLower() == lastName.ToLower());
        }

        /// <summary>
        /// Retrieves companies founded more than a specified number of years ago.
        /// </summary>
        /// <param name="companies">The collection of companies to search.</param>
        /// <param name="years">The number of years.</param>
        /// <returns>A collection of companies founded more than the specified number of years ago.</returns>
        public static IEnumerable<Company> FoundedMoreThanYearsAgo(this IEnumerable<Company> companies, int years)
        {
            DateTime thresholdDate = DateTime.Now.AddYears(-years);
            return companies.Where(c => c.DateOfFoundation < thresholdDate);
        }

        /// <summary>
        /// Retrieves companies founded a specified number of days ago.
        /// </summary>
        /// <param name="companies">The collection of companies to search.</param>
        /// <param name="days">The number of days.</param>
        /// <returns>A collection of companies founded the specified number of days ago.</returns>
        public static IEnumerable<Company> FoundedDaysAgo(this IEnumerable<Company> companies, int days)
        {
            DateTime thresholdDate = DateTime.Now.AddDays(-days);
            return companies.Where(c => c.DateOfFoundation == thresholdDate);
        }

        /// <summary>
        /// Retrieves companies with a director's last name and a specified keyword in their titles.
        /// </summary>
        /// <param name="companies">The collection of companies to search.</param>
        /// <param name="lastName">The last name of the director.</param>
        /// <param name="keyword">The keyword to search for in company titles.</param>
        /// <returns>A collection of companies matching the specified director's last name and keyword.</returns>
        public static IEnumerable<Company> WithDirectorLastNameAndKeywordInTitle(this IEnumerable<Company> companies, string lastName, string keyword)
        {
            return companies.Where(c => c.DirectorFullName.Split(' ').Last().ToLower() == lastName.ToLower() && c.Name.Contains(keyword));
        }
    }

    /// <summary>
    /// Main program class containing the entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            // Sample data
            List<Company> companies = new List<Company>
        {
            new Company { Name = "ABC Marketing", DateOfFoundation = new DateTime(2000, 1, 1), BusinessProfile = "Marketing", DirectorFullName = "John White", NumberOfEmployees = 150, Address = "London, UK" },
            new Company { Name = "XYZ Tech", DateOfFoundation = new DateTime(2015, 5, 10), BusinessProfile = "IT", DirectorFullName = "Alice Smith", NumberOfEmployees = 200, Address = "New York, USA" },
            new Company { Name = "Foodies Inc", DateOfFoundation = new DateTime(1995, 9, 20), BusinessProfile = "Food", DirectorFullName = "Bob White", NumberOfEmployees = 80, Address = "Paris, France" }
        };

            // Test queries
            Console.WriteLine("All companies:");
            PrintCompanies(companies);

            Console.WriteLine("\nCompanies with 'Food' in title:");
            PrintCompanies(companies.WithKeywordInTitle("Food"));

            Console.WriteLine("\nCompanies in marketing:");
            PrintCompanies(companies.InMarketing());

            Console.WriteLine("\nCompanies in marketing or IT:");
            PrintCompanies(companies.InMarketingOrIT());

            Console.WriteLine("\nCompanies with more than 100 employees:");
            PrintCompanies(companies.WithMoreThan100Employees());

            Console.WriteLine("\nCompanies with 100 to 300 employees:");
            PrintCompanies(companies.WithEmployeesInRange(100, 300));

            Console.WriteLine("\nCompanies based in London:");
            PrintCompanies(companies.BasedIn("London"));

            Console.WriteLine("\nCompanies with director's last name 'White':");
            PrintCompanies(companies.WithDirectorLastName("White"));

            Console.WriteLine("\nCompanies founded more than 2 years ago:");
            PrintCompanies(companies.FoundedMoreThanYearsAgo(2));

            Console.WriteLine("\nCompanies founded 123 days ago:");
            PrintCompanies(companies.FoundedDaysAgo(123));

            Console.WriteLine("\nCompanies with director's last name 'Smith' and name containing 'White':");
            PrintCompanies(companies.WithDirectorLastNameAndKeywordInTitle("Smith", "White"));
        }

        /// <summary>
        /// Prints a list of companies to the console.
        /// </summary>
        /// <param name="companies">The list of companies to print.</param>
        static void PrintCompanies(IEnumerable<Company> companies)
        {
            foreach (var company in companies)
            {
                Console.WriteLine($"Name: {company.Name}, Director: {company.DirectorFullName}, Employees: {company.NumberOfEmployees}, Founded: {company.DateOfFoundation}, Address: {company.Address}");
            }
        }
    }
}