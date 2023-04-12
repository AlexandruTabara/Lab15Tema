partial class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>()
        {
            new Student("Tabara", "Alex", 27, Specialisation.ComputerScience),
            new Student("Tabara", "Madalina", 27, Specialisation.ComputerScience),
            new Student("Thor", "Bator", 44, Specialisation.ComputerScience),
            new Student("Pop", "Boc", 19, Specialisation.Construction),
            new Student("Lemnescu", "Eminescu", 39, Specialisation.Letters),
            new Student("Hatz", "John", 23, Specialisation.Construction),
            new Student("Mirca", "Solomon", 29, Specialisation.Letters),
            new Student("Petru", "Melcu", 16, Specialisation.Letters),
        };

        // Display the oldest student from Computer Science
        var oldestComputerScienceStudent = students.Where(s => s.Major == Specialisation.ComputerScience)
                                                   .OrderByDescending(s => s.Age)
                                                   .FirstOrDefault();
        Console.WriteLine(oldestComputerScienceStudent);

        // Display the youngest student in several ways
        var youngestStudent1 = students.OrderBy(s => s.Age).FirstOrDefault();
        Console.WriteLine(youngestStudent1);
        var youngestStudent2 = students.Aggregate((s1, s2) => s1.Age < s2.Age ? s1 : s2);
        Console.WriteLine(youngestStudent2);
        // Display in ascending order of age all students in the literature department
        students
            .Where(s => s.Major == Specialisation.Letters)
            .OrderBy(students => students.Age)
            .ToList()
            .ForEach(s=>Console.WriteLine(s));

        // Display the first construction student with over 20 years of age
        var firstConstructionStudentOver20 = students.Where(s => s.Major == Specialisation.Construction && s.Age > 20).FirstOrDefault();
        Console.WriteLine(firstConstructionStudentOver20);

        // Display students aged average age of students
        var averageAge = students.Average(s=> s.Age);
        Console.WriteLine(averageAge);

        // Display in descending order of age, and in alphabetical order, by name, surname and first name, all students aged between 18 and 35 years
        students
            .Where(s => s.Age >= 18 && s.Age <= 35)
            .OrderBy(students => students.Age)
            .ThenBy(s => s.Name)
            .ThenBy(s => s.FirstName)
            .ToList()
            .ForEach(s=>Console.WriteLine(s));
    

        // Show the last student on the list using LINQ
        var lastStudent = students.LastOrDefault();
        Console.WriteLine(lastStudent);

        // Check if there are minors in the list
        if(students.Any(s=> s.Age < 18))
        {
            Console.WriteLine("There are minors");
        }
        else
        {
            Console.WriteLine("No minors");
        }

        // Group students by age and display them
        var groupedStudents = students.GroupBy(s => s.Age).ToList();
        foreach(var group in groupedStudents) 
        {
            Console.WriteLine($"Students aged {group.Key}:");
            foreach(var student in group) 
            { 
                Console.WriteLine(student); 
            }
            Console.WriteLine();
         }
    }
}
