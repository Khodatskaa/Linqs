namespace Linqs
{
    /// <summary>
    /// Represents information about an employee.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// The full name of the employee.
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// The position of the employee.
        /// </summary>
        public required string Position { get; set; }

        /// <summary>
        /// The contact number of the employee.
        /// </summary>
        public required string ContactNumber { get; set; }

        /// <summary>
        /// The email of the employee.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// The salary of the employee.
        /// </summary>
        public decimal Salary { get; set; }
    }

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

        /// <summary>
        /// The list of employees in the company.
        /// </summary>
        public required List<Employee> Employees { get; set; }
    }

    /// <summary>
    /// Provides queries to retrieve information about companies and employees.
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

        // Other queries from the previous task are retained...

        /// <summary>
        /// Retrieves all employees of a particular company.
        /// </summary>
        /// <param name="companyName">The name of the company.</param>
        /// <returns>A list of all employees of the specified company.</returns>
        public List<Employee> GetAllEmployeesOfCompany(string companyName)
        {
            var company = companies.FirstOrDefault(c => c.Name == companyName);
            return company?.Employees ?? new List<Employee>();
        }

        /// <summary>
        /// Retrieves all employees of a particular company whose salary is higher than a given value.
        /// </summary>
        /// <param name="companyName">The name of the company.</param>
        /// <param name="minSalary">The minimum salary.</param>
        /// <returns>A list of employees whose salary is higher than the specified value.</returns>
        public List<Employee> GetEmployeesWithSalaryHigherThan(string companyName, decimal minSalary)
        {
            var company = companies.FirstOrDefault(c => c.Name == companyName);
            return company?.Employees.Where(e => e.Salary > minSalary).ToList() ?? new List<Employee>();
        }

        /// <summary>
        /// Retrieves employees of all companies that have a manager position.
        /// </summary>
        /// <returns>A list of employees with a manager position.</returns>
        public List<Employee> GetManagerEmployees()
        {
            return companies.SelectMany(c => c.Employees).Where(e => e.Position.ToLower() == "manager").ToList();
        }

        /// <summary>
        /// Retrieves employees whose phone number starts with a specified prefix.
        /// </summary>
        /// <param name="phoneNumberPrefix">The prefix of the phone number.</param>
        /// <returns>A list of employees whose phone number starts with the specified prefix.</returns>
        public List<Employee> GetEmployeesWithPhoneNumberStartingWith(string phoneNumberPrefix)
        {
            return companies.SelectMany(c => c.Employees).Where(e => e.ContactNumber.StartsWith(phoneNumberPrefix)).ToList();
        }

        /// <summary>
        /// Retrieves employees whose email starts with a specified prefix.
        /// </summary>
        /// <param name="emailPrefix">The prefix of the email.</param>
        /// <returns>A list of employees whose email starts with the specified prefix.</returns>
        public List<Employee> GetEmployeesWithEmailStartingWith(string emailPrefix)
        {
            return companies.SelectMany(c => c.Employees).Where(e => e.Email.ToLower().StartsWith(emailPrefix.ToLower())).ToList();
        }

        /// <summary>
        /// Retrieves employees with a specified full name.
        /// </summary>
        /// <param name="fullName">The full name of the employee.</param>
        /// <returns>A list of employees with the specified full name.</returns>
        public List<Employee> GetEmployeesWithFullName(string fullName)
        {
            return companies.SelectMany(c => c.Employees).Where(e => e.FullName.ToLower() == fullName.ToLower()).ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Company> companies = new List<Company>
        {
            new Company
            {
                Name = "ABC Marketing",
                DateOfFoundation = new DateTime(2000, 1, 1),
                BusinessProfile = "Marketing",
                DirectorFullName = "John White",
                NumberOfEmployees = 150,
                Address = "London, UK",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "Alice Johnson", Position = "Manager", ContactNumber = "234567890", Email = "alice@example.com", Salary = 50000 },
                    new Employee { FullName = "Bob Smith", Position = "Assistant", ContactNumber = "123456789", Email = "bob@example.com", Salary = 40000 }
                }
            },
            new Company
            {
                Name = "XYZ Tech",
                DateOfFoundation = new DateTime(2015, 5, 10),
                BusinessProfile = "IT",
                DirectorFullName = "Alice Smith",
                NumberOfEmployees = 200,
                Address = "New York, USA",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "Lionel Messi", Position = "Manager", ContactNumber = "235678901", Email = "messi@example.com", Salary = 60000 },
                    new Employee { FullName = "David Beckham", Position = "Developer", ContactNumber = "234567891", Email = "david@example.com", Salary = 55000 }
                }
            }
        };

            CompanyQueries queries = new CompanyQueries(companies);

            Console.WriteLine("Employees of ABC Marketing:");
            PrintEmployees(queries.GetAllEmployeesOfCompany("ABC Marketing"));

            Console.WriteLine("\nEmployees with salary higher than $45,000 at XYZ Tech:");
            PrintEmployees(queries.GetEmployeesWithSalaryHigherThan("XYZ Tech", 45000));

            Console.WriteLine("\nManager employees across all companies:");
            PrintEmployees(queries.GetManagerEmployees());

            Console.WriteLine("\nEmployees with phone number starting with '23':");
            PrintEmployees(queries.GetEmployeesWithPhoneNumberStartingWith("23"));

            Console.WriteLine("\nEmployees with email starting with 'di':");
            PrintEmployees(queries.GetEmployeesWithEmailStartingWith("di"));

            Console.WriteLine("\nEmployees named Lionel:");
            PrintEmployees(queries.GetEmployeesWithFullName("Lionel"));
        }

        static void PrintEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"Name: {employee.FullName}, Position: {employee.Position}, Contact: {employee.ContactNumber}, Email: {employee.Email}, Salary: {employee.Salary}");
            }
        }
    }
}
