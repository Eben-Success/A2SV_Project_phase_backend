using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class Student
{
    
    public string Name { get; set; }
    public int Age { get; set; }
    public int Grade { get; set; }
    public readonly int rollNumber = 1000;
    public int ID { get; set; }

    public Student(string name, int age, int grade)
    {
        Name = name;
        Age = age;
        ID = rollNumber + 1;
        Grade = grade;
    }

    public override string ToString()
    {
        return $"StudentID: {ID}\n Name: {Name} \nAge: {Age}\nGrade: {Grade}"; aa
    }
}

class StudentList<T> where T : Student
{
    public List<T> Students { get; set; }
    
    public StudentList()
    {
        Students = new List<T>();
    }

    public void AddStudent(T student)
    {
        Students.Add(student);
    }

    public void DisplayStudents()
    {
        Console.WriteLine("Student List: ");
        foreach (T student in Students)
        {
            Console.WriteLine(student);
        }
    }

    public List<T> SearchByName(string name)
    {
        return Students.Where(student => student.Name == name).ToList();
    }

    public T SearchByRollNumber(int rollNumber)
    {
        return Students.FirstOrDefault(student => student.ID == rollNumber);
    }

    public async void SerializeToFile(string filePath)
    {
        try
        {
            string json = JsonConvert.SerializeObject(Students);
            await File.WriteAllTextAsync(filePath, json);

            Console.WriteLine("Serialization successful");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error during serialization: {e.Message}");
        }
    }

    public async void DeserializeFromFile(string FilePath)
    {
        try
        {
            string json = File.ReadAllText(FilePath);
            Students = JsonConvert.DeserializeObject<List<T>>(json);
            Console.WriteLine("Deserialization successful.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error during deserialization: {e.Message}");
        }
        
    }
}

class Program
{
    static void Main()
    {
        StudentList<Student> studentList = new StudentList<Student>();
        bool startApp = true;

        while (startApp)
        {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display Students ");
            Console.WriteLine("3. Search Student by Name ");
            Console.WriteLine("4. Search by ID: ");
            Console.WriteLine("4. Exit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter student name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter student age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter student grade: ");
                    int grade = int.Parse(Console.ReadLine());
                    
                    studentList.AddStudent(new Student(name, age, grade));
                    Console.WriteLine("Student added successfully");
                    break;
                
                case "2": 
                    studentList.DisplayStudents();
                    break;
                
                case "3":
                    Console.WriteLine("Enter student name to search: ");
                    string studentName = Console.ReadLine();
                    var searchResultByName = studentList.SearchByName(studentName);
                    Console.WriteLine("____Search Result____");

                    foreach (var student in searchResultByName)
                    {
                        Console.WriteLine(student);
                    }

                    break;
                
                case "4":
                    Console.WriteLine("Enter student ID to search");
                    int studentID = int.Parse(Console.ReadLine());
                    var searchResult = studentList.SearchByRollNumber(studentID);
                    if (studentID != null)
                    {
                        Console.WriteLine("____Search Result____");
                        Console.WriteLine(searchResult);
                    }
                    else
                    {
                        Console.WriteLine("No student found with the given ID!");
                    }

                    break;
                
                case "5":
                    startApp = false;
                    Console.WriteLine("Exiting Application ....");
                    break;
                
                default:
                    Console.WriteLine("Invalid option. Please try again");
                    continue;
            }
            
            {
                
            }
        }

    }
}