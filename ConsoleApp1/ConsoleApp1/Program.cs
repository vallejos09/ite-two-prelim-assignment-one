using System;
using System.Collections.Generic;

// =========================
// STUDENT CLASS (ONE STUDENT)
// =========================
class Student
{
    private string name;
    private List<double> grades;

    public Student(string name, double g1, double g2, double g3)
    {
        this.name = name;

        grades = new List<double>();
        grades.Add(g1);
        grades.Add(g2);
        grades.Add(g3);
    }

    public string GetName()
    {
        return name;
    }

    public List<double> GetGrades()
    {
        return grades;
    }

    public double GetAverage()
    {
        double sum = 0;

        foreach (double grade in grades)
        {
            sum += grade;
        }

        return sum / grades.Count;
    }
}

// =========================
// STUDENT MANAGER (LOGIC)
// =========================
class StudentManager
{
    private List<Student> students = new List<Student>();

    public void AddStudent(string name, double g1, double g2, double g3)
    {
        Student s = new Student(name, g1, g2, g3);
        students.Add(s);
    }

    public List<string> GetAllStudents()
    {
        List<string> result = new List<string>();

        foreach (Student s in students)
        {
            List<double> g = s.GetGrades();

            string data =
                "Name: " + s.GetName() + "\n" +
                "Grades: " + g[0] + ", " + g[1] + ", " + g[2] + "\n" +
                "Average: " + s.GetAverage().ToString("F2");

            result.Add(data);
        }

        return result;
    }

    public double GetClassAverage()
    {
        if (students.Count == 0)
            return 0;

        double sum = 0;

        foreach (Student s in students)
        {
            sum += s.GetAverage();
        }

        return sum / students.Count;
    }

    public string GetTopStudent()
    {
        if (students.Count == 0)
            return "No students available.";

        Student top = students[0];

        foreach (Student s in students)
        {
            if (s.GetAverage() > top.GetAverage())
            {
                top = s;
            }
        }

        return "Top Student: " + top.GetName() +
               "\nHighest Grade: " + top.GetAverage().ToString("F2");
    }
}

// =========================
// MAIN PROGRAM (INPUT/OUTPUT)
// =========================
class Program
{
    static void Main()
    {
        StudentManager manager = new StudentManager();

        while (true)
        {
            Console.WriteLine("===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==========================");
            Console.Write("Choose an option: ");

            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1)
            {
                Console.Write("Enter student name: ");
                string name = Console.ReadLine();

                Console.Write("Enter grade 1: ");
                double g1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter grade 2: ");
                double g2 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter grade 3: ");
                double g3 = Convert.ToDouble(Console.ReadLine());

                manager.AddStudent(name, g1, g2, g3);

                Console.WriteLine("Student added successfully!\n");
            }
            else if (choice == 2)
            {
                List<string> students = manager.GetAllStudents();

                foreach (string s in students)
                {
                    Console.WriteLine(s);
                    Console.WriteLine();
                }
            }
            else if (choice == 3)
            {
                double avg = manager.GetClassAverage();

                Console.WriteLine("===== CLASS AVERAGE =====");
                Console.WriteLine("Overall Average Grade: " + avg.ToString("F2") + "\n");
            }
            else if (choice == 4)
            {
                Console.WriteLine("===== HIGHEST GRADE =====");
                Console.WriteLine(manager.GetTopStudent());
                Console.WriteLine();
            }
            else if (choice == 5)
            {
                Console.WriteLine("Exiting program...");
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option!\n");
            }
        }
    }
}
