namespace Linqs
{
    public class Company
    {
        public string Name { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public string BusinessProfile { get; set; }
        public string DirectorFullName { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Address { get; set; }
    }

    public static class CompanyExtensions
    {
        public static IEnumerable<Company> WithKeywordInTitle(this IEnumerable<Company> companies, string keyword)
        {
            return companies.Where(c => c.Name.Contains(keyword));
        }

        public static IEnumerable<Company> InMarketing(this IEnumerable<Company> companies)
        {
            return companies.Where(c => c.BusinessProfile.ToLower() == "marketing");
        }

        public static IEnumerable<Company> InMarketingOrIT(this IEnumerable<Company> companies)
        {
            return companies.Where(c => c.BusinessProfile.ToLower() == "marketing" || c.BusinessProfile.ToLower() == "it");
        }

        public static IEnumerable<Company> WithMoreThan100Employees(this IEnumerable<Company> companies)
        {
            return companies.Where(c => c.NumberOfEmployees > 100);
        }

        public static IEnumerable<Company> WithEmployeesInRange(this IEnumerable<Company> companies, int minEmployees, int maxEmployees)
        {
            return companies.Where(c => c.NumberOfEmployees >= minEmployees && c.NumberOfEmployees <= maxEmployees);
        }

        public static IEnumerable<Company> BasedIn(this IEnumerable<Company> companies, string city)
        {
            return companies.Where(c => c.Address.ToLower().Contains(city.ToLower()));
        }

        public static IEnumerable<Company> WithDirectorLastName(this IEnumerable<Company> companies, string lastName)
        {
            return companies.Where(c => c.DirectorFullName.Split(' ').Last().ToLower() == lastName.ToLower());
        }

        public static IEnumerable<Company> FoundedMoreThanYearsAgo(this IEnumerable<Company> companies, int years)
        {
            DateTime thresholdDate = DateTime.Now.AddYears(-years);
            return companies.Where(c => c.DateOfFoundation < thresholdDate);
        }

        public static IEnumerable<Company> FoundedDaysAgo(this IEnumerable<Company> companies, int days)
        {
            DateTime thresholdDate = DateTime.Now.AddDays(-days);
            return companies.Where(c => c.DateOfFoundation == thresholdDate);
        }

        public static IEnumerable<Company> WithDirectorLastNameAndKeywordInTitle(this IEnumerable<Company> companies, string lastName, string keyword)
        {
            return companies.Where(c => c.DirectorFullName.Split(' ').Last().ToLower() == lastName.ToLower() && c.Name.Contains(keyword));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Company> companies = new List<Company>
            {
                new Company { Name = "ABC Marketing", DateOfFoundation = new DateTime(2000, 1, 1), BusinessProfile = "Marketing", DirectorFullName = "John White", NumberOfEmployees = 150, Address = "London, UK" },
                new Company { Name = "XYZ Tech", DateOfFoundation = new DateTime(2015, 5, 10), BusinessProfile = "IT", DirectorFullName = "Alice Smith", NumberOfEmployees = 200, Address = "New York, USA" },
                new Company { Name = "Foodies Inc", DateOfFoundation = new DateTime(1995, 9, 20), BusinessProfile = "Food", DirectorFullName = "Bob White", NumberOfEmployees = 80, Address = "Paris, France" }
            };

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

        static void PrintCompanies(IEnumerable<Company> companies)
        {
            foreach (var company in companies)
            {
                Console.WriteLine($"Name: {company.Name}, Director: {company.DirectorFullName}, Employees: {company.NumberOfEmployees}, Founded: {company.DateOfFoundation}, Address: {company.Address}");
            }
        }
    }
}