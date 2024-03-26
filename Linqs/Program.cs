namespace Linqs
{
    public class Student
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public int Age { get; set; }
        public required string Institution { get; set; }
    }

    public static class StudentQueries
    {
        /// <summary>
        /// Get an entire array of students.
        /// </summary>
        /// <param name="students">Array of students</param>
        /// <returns>Array of students</returns>
        public static Student[] GetAllStudents(Student[] students)
        {
            return students;
        }

        /// <summary>
        /// Get the students' data with the name "Boris".
        /// </summary>
        /// <param name="students">Array of students</param>
        /// <returns>Array of students with name "Boris"</returns>
        public static Student[] GetStudentsWithNameBoris(Student[] students)
        {
            return students.Where(student => student.Name == "Boris").ToArray();
        }

        /// <summary>
        /// Get the students' data whose surname starts with "Bro".
        /// </summary>
        /// <param name="students">Array of students</param>
        /// <returns>Array of students whose surname starts with "Bro"</returns>
        public static Student[] GetStudentsWithSurnameStartingWithBro(Student[] students)
        {
            return students.Where(student => student.Surname.StartsWith("Bro")).ToArray();
        }

        /// <summary>
        /// Get the students' data who are over 19.
        /// </summary>
        /// <param name="students">Array of students</param>
        /// <returns>Array of students over 19 years old</returns>
        public static Student[] GetStudentsOver19(Student[] students)
        {
            return students.Where(student => student.Age > 19).ToArray();
        }

        /// <summary>
        /// Get the students' data who are over 20 and under 23.
        /// </summary>
        /// <param name="students">Array of students</param>
        /// <returns>Array of students between 20 and 23 years old</returns>
        public static Student[] GetStudentsBetween20And23(Student[] students)
        {
            return students.Where(student => student.Age > 20 && student.Age < 23).ToArray();
        }

        /// <summary>
        /// Get the students' data who study at MIT.
        /// </summary>
        /// <param name="students">Array of students</param>
        /// <returns>Array of students studying at MIT</returns>
        public static Student[] GetStudentsAtMIT(Student[] students)
        {
            return students.Where(student => student.Institution == "MIT").ToArray();
        }

        /// <summary>
        /// Get the students' data who study at Oxford, and they are over 18. Sort the result by age in descending order.
        /// </summary>
        /// <param name="students">Array of students</param>
        /// <returns>Array of students studying at Oxford and over 18, sorted by age in descending order</returns>
        public static Student[] GetStudentsAtOxfordOver18SortedByAgeDescending(Student[] students)
        {
            return students.Where(student => student.Institution == "Oxford" && student.Age > 18)
                           .OrderByDescending(student => student.Age)
                           .ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = {
            new Student { Name = "John", Surname = "Brown", Age = 22, Institution = "MIT" },
            new Student { Name = "Boris", Surname = "Smith", Age = 20, Institution = "Oxford" },
            new Student { Name = "Alice", Surname = "Brooks", Age = 21, Institution = "MIT" },
            new Student { Name = "Boris", Surname = "Johnson", Age = 23, Institution = "Oxford" },
            new Student { Name = "Emily", Surname = "Brooks", Age = 19, Institution = "Oxford" },
            new Student { Name = "Adam", Surname = "Brown", Age = 18, Institution = "MIT" }
            };

            Console.WriteLine("All students:");
            PrintStudents(StudentQueries.GetAllStudents(students));

            Console.WriteLine("\nStudents with name 'Boris':");
            PrintStudents(StudentQueries.GetStudentsWithNameBoris(students));

            Console.WriteLine("\nStudents whose surname starts with 'Bro':");
            PrintStudents(StudentQueries.GetStudentsWithSurnameStartingWithBro(students));

            Console.WriteLine("\nStudents over 19 years old:");
            PrintStudents(StudentQueries.GetStudentsOver19(students));

            Console.WriteLine("\nStudents between 20 and 23 years old:");
            PrintStudents(StudentQueries.GetStudentsBetween20And23(students));

            Console.WriteLine("\nStudents studying at MIT:");
            PrintStudents(StudentQueries.GetStudentsAtMIT(students));

            Console.WriteLine("\nStudents studying at Oxford and over 18, sorted by age in descending order:");
            PrintStudents(StudentQueries.GetStudentsAtOxfordOver18SortedByAgeDescending(students));
        }

        static void PrintStudents(Student[] students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Institution: {student.Institution}");
            }
        }
    }
}
