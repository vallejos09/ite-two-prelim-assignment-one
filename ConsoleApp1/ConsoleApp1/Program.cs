using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    class Program
    {
        static List<string> studentNames = new List<string>();
        static List<double> studentGrades = new List<double>();

        static void Main(string[] join)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n====================================");
                Console.WriteLine("     STUDENT MANAGEMENT SYSTEM      ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Student Record");
                Console.WriteLine("2. View All Student Records");
                Console.WriteLine("3. View Class Summary & Analytics");
                Console.WriteLine("4. Exit");
                Console.WriteLine("====================================");
                Console.Write("Enter your choice (1-4): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudentRecord();
                        break;
                    case "2":
                        ViewStudentRecords();
                        break;
                    case "3":
                        ViewClassSummary();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program. Thank you!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select a valid option from 1 to 4.");
                        break;
                }
            }
        }
        static void AddStudentRecord()
        {
            Console.WriteLine("--- ADD NEW STUDENT RECORD ---");

            string name = "";
            while (true)
            {
                Console.Write("Enter Student Name: ");
                name = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(name))
                {
                    break;
                }
                Console.WriteLine("Name cannot be empty. Please enter a valid name.");
            }

            double grade = 0;
            while (true)
            {
                Console.Write("Enter Student Grade (0 - 100): ");
                string gradeInput = Console.ReadLine();
                if (double.TryParse(gradeInput, out grade))
                {
                    if (grade >= 0 && grade <= 100)
                    {
                        break;
                    }
                }
                Console.WriteLine("Invalid Input! Grade must be a numerical value between 0 and 100.");
            }

            studentNames.Add(name);
            studentGrades.Add(grade);

            Console.WriteLine($"\nSuccess: Record for '{name}' with grade {grade:F2} has been saved.");
        }

        static void ViewStudentRecords()
        {
            Console.WriteLine("--- ALL STUDENT RECORDS ---");

            if (studentNames.Count == 0)
            {
                Console.WriteLine("No records found. Please add students first.");
                return;
            }

            Console.WriteLine("------------------------------------");
            Console.WriteLine(String.Format("{0,-5} | {1,-20} | {2,-10}", "No.", "Student Name", "Grade"));
            Console.WriteLine("------------------------------------");

            for (int i = 0; i < studentNames.Count; i++)
            {
                Console.WriteLine(String.Format("{0,-5} | {1,-20} | {2,-10:F2}", (i + 1), studentNames[i], studentGrades[i]));
            }
            Console.WriteLine("------------------------------------");
        }
        static void ViewClassSummary()
        {
            Console.WriteLine("--- CLASS SUMMARY & ANALYTICS ---");

            if (studentNames.Count == 0)
            {
                Console.WriteLine("No data available to compute analytics. Add records first.");
                return;
            }

            double totalSum = 0;
            double highestGrade = studentGrades[0];
            string topStudent = studentNames[0];

            for (int i = 0; i < studentGrades.Count; i++)
            {
                totalSum += studentGrades[i];
                if (studentGrades[i] > highestGrade)
                {
                    highestGrade = studentGrades[i];
                    topStudent = studentNames[i];
                }
            }

            double classAverage = totalSum / studentGrades.Count;
            Console.WriteLine($"Total Students Enrolled : {studentNames.Count}");
            Console.WriteLine($"Class Average Grade     : {classAverage:F2}");
            Console.WriteLine($"Highest Grade in Class  : {highestGrade:F2}");
            Console.WriteLine($"Top Performing Student  : {topStudent}");
            Console.WriteLine("------------------------------------");
        }
    }
}