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
    /// Provides queries to retrieve information about companies.
    /// </summary>
    public class CompanyQueries
    {
        private List<Company> companies;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyQueries"/> class.
        /// </summary>
        /// <param name="companies">The list of companies to perform queries on.</param>
        public CompanyQueries(List<Company> companies)
        {
            this.companies = companies;
        }

        /// <summary>
        /// Retrieves information about all companies.
        /// </summary>
        /// <returns>A list of all companies.</returns>
        public List<Company> GetAllCompanies()
        {
            return companies;
        }

        /// <summary>
        /// Retrieves a list of companies with a specified keyword in their titles.
        /// </summary>
        /// <param name="keyword">The keyword to search for in company titles.</param>
        /// <returns>A list of companies matching the specified keyword.</returns>
        public List<Company> GetCompaniesWithKeywordInTitle(string keyword)
        {
            return companies.Where(c => c.Name.Contains(keyword)).ToList();
        }

        /// <summary>
        /// Retrieves a list of companies in the marketing field.
        /// </summary>
        /// <returns>A list of companies in the marketing field.</returns>
        public List<Company> GetCompaniesInMarketing()
        {
            return companies.Where(c => c.BusinessProfile.ToLower() == "marketing").ToList();
        }

        /// <summary>
        /// Retrieves a list of companies in marketing or IT fields.
        /// </summary>
        /// <returns>A list of companies in marketing or IT fields.</returns>
        public List<Company> GetCompaniesInMarketingOrIT()
        {
            return companies.Where(c => c.BusinessProfile.ToLower() == "marketing" || c.BusinessProfile.ToLower() == "it").ToList();
        }

        /// <summary>
        /// Retrieves a list of companies with more than 100 employees.
        /// </summary>
        /// <returns>A list of companies with more than 100 employees.</returns>
        public List<Company> GetCompaniesWithMoreThan100Employees()
        {
            return companies.Where(c => c.NumberOfEmployees > 100).ToList();
        }

        /// <summary>
        /// Retrieves a list of companies with a specified range of employees.
        /// </summary>
        /// <param name="minEmployees">The minimum number of employees.</param>
        /// <param name="maxEmployees">The maximum number of employees.</param>
        /// <returns>A list of companies within the specified range of employees.</returns>
        public List<Company> GetCompaniesWithEmployeesInRange(int minEmployees, int maxEmployees)
        {
            return companies.Where(c => c.NumberOfEmployees >= minEmployees && c.NumberOfEmployees <= maxEmployees).ToList();
        }

        /// <summary>
        /// Retrieves a list of companies based in a specified city.
        /// </summary>
        /// <param name="city">The city to search for.</param>
        /// <returns>A list of companies based in the specified city.</returns>
        public List<Company> GetCompaniesBasedIn(string city)
        {
            return companies.Where(c => c.Address.ToLower().Contains(city.ToLower())).ToList();
        }

        /// <summary>
        /// Retrieves a list of companies with a specified director's last name.
        /// </summary>
        /// <param name="lastName">The last name of the director.</param>
        /// <returns>A list of companies with the specified director's last name.</returns>
        public List<Company> GetCompaniesWithDirectorLastName(string lastName)
        {
            return companies.Where(c => c.DirectorFullName.Split(' ').Last().ToLower() == lastName.ToLower()).ToList();
        }

        /// <summary>
        /// Retrieves a list of companies founded more than a specified number of years ago.
        /// </summary>
        /// <param name="years">The number of years.</param>
        /// <returns>A list of companies founded more than the specified number of years ago.</returns>
        public List<Company> GetCompaniesFoundedMoreThanYearsAgo(int years)
        {
            DateTime thresholdDate = DateTime.Now.AddYears(-years);
            return companies.Where(c => c.DateOfFoundation < thresholdDate).ToList();
        }

        /// <summary>
        /// Retrieves a list of companies founded a specified number of days ago.
        /// </summary>
        /// <param name="days">The number of days.</param>
        /// <returns>A list of companies founded the specified number of days ago.</returns>
        public List<Company> GetCompaniesFoundedDaysAgo(int days)
        {
            DateTime thresholdDate = DateTime.Now.AddDays(-days);
            return companies.Where(c => c.DateOfFoundation == thresholdDate).ToList();
        }

        /// <summary>
        /// Retrieves a list of companies with a director's last name and a specified keyword in their titles.
        /// </summary>
        /// <param name="lastName">The last name of the director.</param>
        /// <param name="keyword">The keyword to search for in company titles.</param>
        /// <returns>A list of companies matching the specified director's last name and keyword.</returns>
        public List<Company> GetCompaniesWithDirectorLastNameAndKeywordInTitle(string lastName, string keyword)
        {
            return companies.Where(c => c.DirectorFullName.Split(' ').Last().ToLower() == lastName.ToLower() && c.Name.Contains(keyword)).ToList();
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

            CompanyQueries queries = new CompanyQueries(companies);

            // Test queries
            Console.WriteLine("All companies:");
            PrintCompanies(queries.GetAllCompanies());

            Console.WriteLine("\nCompanies with 'Food' in title:");
            PrintCompanies(queries.GetCompaniesWithKeywordInTitle("Food"));

            Console.WriteLine("\nCompanies in marketing:");
            PrintCompanies(queries.GetCompaniesInMarketing());

            Console.WriteLine("\nCompanies in marketing or IT:");
            PrintCompanies(queries.GetCompaniesInMarketingOrIT());

            Console.WriteLine("\nCompanies with more than 100 employees:");
            PrintCompanies(queries.GetCompaniesWithMoreThan100Employees());

            Console.WriteLine("\nCompanies with 100 to 300 employees:");
            PrintCompanies(queries.GetCompaniesWithEmployeesInRange(100, 300));

            Console.WriteLine("\nCompanies based in London:");
            PrintCompanies(queries.GetCompaniesBasedIn("London"));

            Console.WriteLine("\nCompanies with director's last name 'White':");
            PrintCompanies(queries.GetCompaniesWithDirectorLastName("White"));

            Console.WriteLine("\nCompanies founded more than 2 years ago:");
            PrintCompanies(queries.GetCompaniesFoundedMoreThanYearsAgo(2));

            Console.WriteLine("\nCompanies founded 123 days ago:");
            PrintCompanies(queries.GetCompaniesFoundedDaysAgo(123));

            Console.WriteLine("\nCompanies with director's last name 'Smith' and name containing 'White':");
            PrintCompanies(queries.GetCompaniesWithDirectorLastNameAndKeywordInTitle("Smith", "White"));
        }

        /// <summary>
        /// Prints a list of companies to the console.
        /// </summary>
        /// <param name="companies">The list of companies to print.</param>
        static void PrintCompanies(List<Company> companies)
        {
            foreach (var company in companies)
            {
                Console.WriteLine($"Name: {company.Name}, Director: {company.DirectorFullName}, Employees: {company.NumberOfEmployees}, Founded: {company.DateOfFoundation}, Address: {company.Address}");
            }
        }
    }
}
