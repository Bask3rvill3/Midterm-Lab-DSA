using System;

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
        Student[] students = new Student[10];
        int studentCount = 0;
        int choice;

        do
        {
            Console.WriteLine("======================================");
            Console.WriteLine("      STUDENT RECORD MANAGEMENT       ");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.Write("\nEnter choice: ");
            
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    if (studentCount >= 10)
                    {
                        Console.WriteLine("\nStorage is full! Cannot add more students.");
                        break;
                    }
                    Student newStudent = new Student();
                    Console.Write("Enter Student Number: ");
                    newStudent.StudentNumber = Console.ReadLine();
                    Console.Write("Enter Name: ");
                    newStudent.Name = Console.ReadLine();
                    Console.Write("Enter Program: ");
                    newStudent.Program = Console.ReadLine();
                    Console.Write("Enter Year Level: ");
                    int.TryParse(Console.ReadLine(), out newStudent.YearLevel);

                    students[studentCount] = newStudent;
                    studentCount++;
                    Console.WriteLine("\nStudent added successfully!");
                    break;

                case 2:
                    Console.WriteLine("\n======================================");
                    Console.WriteLine("           STUDENT RECORDS            ");
                    Console.WriteLine("======================================");
                    if (studentCount == 0)
                    {
                        Console.WriteLine("No records found.");
                    }
                    else
                    {
                        for (int i = 0; i < studentCount; i++)
                        {
                            Console.WriteLine($"Student Number: {students[i].StudentNumber}");
                            Console.WriteLine($"Name: {students[i].Name}");
                            Console.WriteLine($"Program: {students[i].Program}");
                            Console.WriteLine($"Year Level: {students[i].YearLevel}");
                            Console.WriteLine("--------------------------------------");
                        }
                    }
                    break;

                case 3:
                    Console.Write("\nEnter Student Number to search: ");
                    string searchNum = Console.ReadLine();
                    bool found = false;
                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == searchNum)
                        {
                            Console.WriteLine("\nStudent Found!");
                            Console.WriteLine($"Student Number: {students[i].StudentNumber}");
                            Console.WriteLine($"Name: {students[i].Name}");
                            Console.WriteLine($"Program: {students[i].Program}");
                            Console.WriteLine($"Year Level: {students[i].YearLevel}");
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("\nStudent Number does not exist.");
                    }
                    break;

                case 4:
                    Console.Write("\nEnter Student Number to update: ");
                    string updateNum = Console.ReadLine();
                    bool updated = false;
                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == updateNum)
                        {
                            Console.Write("Enter New Name: ");
                            students[i].Name = Console.ReadLine();
                            Console.Write("Enter New Program: ");
                            students[i].Program = Console.ReadLine();
                            Console.Write("Enter New Year Level: ");
                            int.TryParse(Console.ReadLine(), out students[i].YearLevel);
                            Console.WriteLine("\nStudent updated successfully!");
                            updated = true;
                            break;
                        }
                    }
                    if (!updated)
                    {
                        Console.WriteLine("\nStudent Number does not exist.");
                    }
                    break;

                case 5:
                    Console.Write("\nEnter Student Number to delete: ");
                    string deleteNum = Console.ReadLine();
                    bool deleted = false;
                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == deleteNum)
                        {
                            for (int j = i; j < studentCount - 1; j++)
                            {
                                students[j] = students[j + 1];
                            }
                            studentCount--;
                            Console.WriteLine("\nStudent deleted successfully!");
                            deleted = true;
                            break;
                        }
                    }
                    if (!deleted)
                    {
                        Console.WriteLine("\nStudent Number does not exist.");
                    }
                    break;

                case 6:
                    Console.WriteLine("\nProgram exited.");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        } while (choice != 6);
    }
}