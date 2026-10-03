using System;
using System.Collections.Generic;

struct StudentRequest
{
    public string StudentNumber;
    public string StudentName;
    public string RequestType;
}

class Program
{
    static void Main()
    {
        Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();
        int choice;

        do
        {
            Console.WriteLine("======================================");
            Console.WriteLine("         STUDENT REQUEST QUEUE        ");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Add Request");
            Console.WriteLine("2. View Pending Requests");
            Console.WriteLine("3. Process Request");
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
                    StudentRequest req = new StudentRequest();
                    Console.Write("Enter Student Number: ");
                    req.StudentNumber = Console.ReadLine();
                    Console.Write("Enter Student Name: ");
                    req.StudentName = Console.ReadLine();
                    Console.Write("Enter Request Type: ");
                    req.RequestType = Console.ReadLine();

                    requestQueue.Enqueue(req);
                    Console.WriteLine("\nRequest added successfully!");
                    break;

                case 2:
                    Console.WriteLine("\n======================================");
                    Console.WriteLine("            REQUEST QUEUE             ");
                    Console.WriteLine("======================================");
                    if (requestQueue.Count == 0)
                    {
                        Console.WriteLine("No pending requests.");
                    }
                    else
                    {
                        int index = 1;
                        foreach (var r in requestQueue)
                        {
                            Console.WriteLine($"{index}. {r.StudentName} - {r.RequestType} (ID: {r.StudentNumber})");
                            index++;
                        }
                    }
                    break;

                case 3:
                    if (requestQueue.Count == 0)
                    {
                        Console.WriteLine("\nThere are no pending requests, display an appropriate message.");
                    }
                    else
                    {
                        StudentRequest processed = requestQueue.Dequeue();
                        Console.WriteLine($"\nProcessing Request: {processed.StudentName} - {processed.RequestType}");
                        Console.WriteLine("Request processed successfully!");
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