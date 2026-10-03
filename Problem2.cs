using System;
using System.Collections.Generic;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

class Program
{
    static void Main()
    {
        Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();
        int choice;

        do
        {
            Console.WriteLine("======================================");
            Console.WriteLine("    STUDENT LOOKUP USING DICTIONARY   ");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Display All Students");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Student newStudent = new Student();
                    Console.Write("Enter Student Number: ");
                    newStudent.StudentNumber = Console.ReadLine();

                    if (studentDictionary.ContainsKey(newStudent.StudentNumber))
                    {
                        Console.WriteLine("\nError: Duplicate Student Number!");
                        break;
                    }

                    Console.Write("Enter Name: ");
                    newStudent.Name = Console.ReadLine();
                    Console.Write("Enter Program: ");
                    newStudent.Program = Console.ReadLine();
                    Console.Write("Enter Year Level: ");
                    int.TryParse(Console.ReadLine(), out newStudent.YearLevel);

                    studentDictionary.Add(newStudent.StudentNumber, newStudent);
                    Console.WriteLine("\nStudent added successfully!");
                    break;

                case 2:
                    Console.Write("\nEnter Student Number to search: ");
                    string searchNum = Console.ReadLine();

                    if (studentDictionary.TryGetValue(searchNum, out Student foundStudent))
                    {
                        Console.WriteLine("\nStudent Found!");
                        Console.WriteLine($"Student Number: {foundStudent.StudentNumber}");
                        Console.WriteLine($"Name: {foundStudent.Name}");
                        Console.WriteLine($"Program: {foundStudent.Program}");
                        Console.WriteLine($"Year Level: {foundStudent.YearLevel}");
                    }
                    else
                    {
                        Console.WriteLine("\nStudent Number does not exist.");
                    }
                    break;

                case 3:
                    Console.WriteLine("\n======================================");
                    Console.WriteLine("           STUDENT RECORDS            ");
                    Console.WriteLine("======================================");
                    if (studentDictionary.Count == 0)
                    {
                        Console.WriteLine("No records found.");
                    }
                    else
                    {
                        foreach (var kvp in studentDictionary)
                        {
                            Console.WriteLine($"Student Number: {kvp.Value.StudentNumber}");
                            Console.WriteLine($"Name: {kvp.Value.Name}");
                            Console.WriteLine($"Program: {kvp.Value.Program}");
                            Console.WriteLine($"Year Level: {kvp.Value.YearLevel}");
                            Console.WriteLine("--------------------------------------");
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine("\nProgram exited.");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice.");
                    break;
            }
            Console.WriteLine();
        } while (choice != 4);
    }
}