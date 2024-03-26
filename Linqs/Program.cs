namespace Linqs
{
    public class Company
    {
        public required string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public required string BusinessProfile { get; set; }
        public required string DirectorFullName { get; set; }
        public int NumberOfEmployees { get; set; }
        public required string Address { get; set; }
    }

    public static class CompanyQueries
    {
        /// <summary>
        /// Get information about all companies.
        /// </summary>
        /// <param name="companies">Array of companies</param>
        /// <returns>Array of companies</returns>
        public static Company[] GetAllCompanies(Company[] companies)
        {
            return companies;
        }

        /// <summary>
        /// Get the company list have the word "Food" in their titles.
        /// </summary>
        /// <param name="companies">Array of companies</param>
        /// <returns>Array of companies with "Food" in their titles</returns>
        public static Company[] GetCompaniesWithFoodInTitle(Company[] companies)
        {
            return companies.Where(c => c.Name.Contains("Food")).ToArray();
        }

        /// <summary>
        /// Get the company list that work in marketing.
        /// </summary>
        /// <param name="companies">Array of companies</param>
        /// <returns>Array of companies working in marketing</returns>
        public static Company[] GetMarketingCompanies(Company[] companies)
        {
            return companies.Where(company => company.BusinessProfile.ToLower() == "marketing").ToArray();
        }

        /// <summary>
        /// Get the company list that work in marketing or IT.
        /// </summary>
        /// <param name="companies">Array of companies</param>
        /// <returns>Array of companies working in marketing or IT</returns>
        public static Company[] GetMarketingOrITCompanies(Company[] companies)
        {
            return companies.Where(company => company.BusinessProfile.ToLower() == "marketing" || company.BusinessProfile.ToLower() == "it").ToArray();
        }

        /// <summary>
        /// Get the company list with more than 100 employees.
        /// </summary>
        /// <param name="companies">Array of companies</param>
        /// <returns>Array of companies with more than 100 employees</returns>
        public static Company[] GetCompaniesWithMoreThan100Employees(Company[] companies)
        {
            return companies.Where(company => company.NumberOfEmployees > 100).ToArray();
        }

        /// <summary>
        /// Get the company list with 100 to 300 employees.
        /// </summary>
        /// <param name="companies">Array of companies</param>
        /// <returns>Array of companies with 100 to 300 employees</returns>
        public static Company[] GetCompaniesWith100To300Employees(Company[] companies)
        {
            return companies.Where(company => company.NumberOfEmployees >= 100 && company.NumberOfEmployees <= 300).ToArray();
        }

        /// <summary>
        /// Get the company list that are based in London.
        /// </summary>
        /// <param name="companies">Array of companies</param>
        /// <returns>Array of companies based in London</returns>
        public static Company[] GetCompaniesBasedInLondon(Company[] companies)
        {
            return companies.Where(company => company.Address.ToLower().Contains("london")).ToArray();
        }

        /// <summary>
        /// Get the company list with a director's last name White.
        /// </summary>
        /// <param name="companies">Array of companies</param>
        /// <returns>Array of companies with a director's last name White</returns>
        public static Company[] GetCompaniesWithDirectorLastNameWhite(Company[] companies)
        {
            return companies.Where(company => company.DirectorFullName.ToLower().Split(' ').Last() == "white").ToArray();
        }

        /// <summary>
        /// Get the company list that were founded more than two years ago.
        /// </summary>
        /// <param name="companies">Array of companies</param>
        /// <returns>Array of companies founded more than two years ago</returns>
        public static Company[] GetCompaniesFoundedMoreThanTwoYearsAgo(Company[] companies)
        {
            return companies.Where(company => (DateTime.Now - company.FoundationDate).TotalDays > 365 * 2).ToArray();
        }

        /// <summary>
        /// Get the company list that have been 123 days old since they were founded.
        /// </summary>
        /// <param name="companies">Array of companies</param>
        /// <returns>Array of companies that have been 123 days old since they were founded</returns>
        public static Company[] GetCompanies123DaysOld(Company[] companies)
        {
            return companies.Where(company => (DateTime.Now - company.FoundationDate).TotalDays == 123).ToArray();
        }

        /// <summary>
        /// Get the company list that the director's last name is Smith and the company name contains the word "White".
        /// </summary>
        /// <param name="companies">Array of companies</param>
        /// <returns>Array of companies meeting the conditions</returns>
        public static Company[] GetCompaniesDirectorLastNameSmithAndNameContainsWhite(Company[] companies)
        {
            return companies.Where(company => company.DirectorFullName.ToLower().Split(' ').Last() == "smith" && company.Name.ToLower().Contains("white")).ToArray();
        }
    }

    public class Program
    {
        static void Main()
        {
            Company[] companies = {
            new Company { Name = "White Foods Ltd", FoundationDate = new DateTime(2010, 5, 15), BusinessProfile = "Food", DirectorFullName = "John White", NumberOfEmployees = 120, Address = "London" },
            new Company { Name = "Black IT Solutions", FoundationDate = new DateTime(2015, 8, 20), BusinessProfile = "IT", DirectorFullName = "Alice Black", NumberOfEmployees = 250, Address = "Manchester" },
            new Company { Name = "Red Marketing Agency", FoundationDate = new DateTime(2005, 3, 10), BusinessProfile = "Marketing", DirectorFullName = "Robert Red", NumberOfEmployees = 80, Address = "London" },
            new Company { Name = "Blue Logistics", FoundationDate = new DateTime(2018, 12, 5), BusinessProfile = "Logistics", DirectorFullName = "Michael Blue", NumberOfEmployees = 180, Address = "Birmingham" },
            new Company { Name = "Green Technologies", FoundationDate = new DateTime(2012, 10, 30), BusinessProfile = "IT", DirectorFullName = "Sarah Green", NumberOfEmployees = 300, Address = "London" }
            };

            Company[] allCompanies = CompanyQueries.GetAllCompanies(companies);
            Company[] companiesWithFoodInTitle = CompanyQueries.GetCompaniesWithFoodInTitle(companies);
            Company[] marketingCompanies = CompanyQueries.GetMarketingCompanies(companies);
            Company[] marketingOrITCompanies = CompanyQueries.GetMarketingOrITCompanies(companies);
            Company[] companiesWithMoreThan100Employees = CompanyQueries.GetCompaniesWithMoreThan100Employees(companies);
            Company[] companiesWith100To300Employees = CompanyQueries.GetCompaniesWith100To300Employees(companies);
            Company[] companiesBasedInLondon = CompanyQueries.GetCompaniesBasedInLondon(companies);
            Company[] companiesWithDirectorLastNameWhite = CompanyQueries.GetCompaniesWithDirectorLastNameWhite(companies);
            Company[] companiesFoundedMoreThanTwoYearsAgo = CompanyQueries.GetCompaniesFoundedMoreThanTwoYearsAgo(companies);
            Company[] companies123DaysOld = CompanyQueries.GetCompanies123DaysOld(companies);
            Company[] companiesDirectorLastNameSmithAndNameContainsWhite = CompanyQueries.GetCompaniesDirectorLastNameSmithAndNameContainsWhite(companies);

            Console.WriteLine("All companies:");
            foreach (var company in allCompanies)
            {
                Console.WriteLine(company.Name);
            }

            Console.WriteLine("\nCompanies with 'Food' in their titles:");
            foreach (var company in companiesWithFoodInTitle)
            {
                Console.WriteLine(company.Name);
            }

            Console.WriteLine("\nMarketing companies:");
            foreach (var company in marketingCompanies)
            {
                Console.WriteLine(company.Name);
            }

            Console.WriteLine("\nMarketing or IT companies:");
            foreach (var company in marketingOrITCompanies)
            {
                Console.WriteLine(company.Name);
            }

            Console.WriteLine("\nCompanies with more than 100 employees:");
            foreach (var company in companiesWithMoreThan100Employees)
            {
                Console.WriteLine(company.Name);
            }

            Console.WriteLine("\nCompanies with 100 to 300 employees:");
            foreach (var company in companiesWith100To300Employees)
            {
                Console.WriteLine(company.Name);
            }

            Console.WriteLine("\nCompanies based in London:");
            foreach (var company in companiesBasedInLondon)
            {
                Console.WriteLine(company.Name);
            }

            Console.WriteLine("\nCompanies with a director's last name White:");
            foreach (var company in companiesWithDirectorLastNameWhite)
            {
                Console.WriteLine(company.Name);
            }

            Console.WriteLine("\nCompanies founded more than two years ago:");
            foreach (var company in companiesFoundedMoreThanTwoYearsAgo)
            {
                Console.WriteLine(company.Name);
            }

            Console.WriteLine("\nCompanies that have been 123 days old since they were founded:");
            foreach (var company in companies123DaysOld)
            {
                Console.WriteLine(company.Name);
            }

            Console.WriteLine("\nCompanies that the director's last name is Smith and the company name contains the word 'White':");
            foreach (var company in companiesDirectorLastNameSmithAndNameContainsWhite)
            {
                Console.WriteLine(company.Name);
            }
        }
    }
}
