public partial class Program
{
    class Student
    {
            public Guid Id { get; }
            public string Name { get; set; }
            public string FirstName { get; set; }
            public int Age { get; set; }
            public Specialisation Major { get; set; }

            public Student(string name, string firstName, int age, Specialisation major)
            {
                Id = Guid.NewGuid();
                Name = name;
                FirstName = firstName;
                Age = age;
                Major = major;
            }

            public override string ToString()
            {
                return $"Id: {Id}, Name: {Name}, First Name: {FirstName}, Age: {Age}, Major: {Major}";
            }

        }
    }
