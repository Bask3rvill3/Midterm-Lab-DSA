using System;
using System.Collections.Generic;

struct Operation
{
    public string Action;
    public string StudentNumber;
    public string StudentName;
}

class Program
{
    static void Main()
    {
        Stack<Operation> operationHistory = new Stack<Operation>();
        int choice;

        do
        {
            Console.WriteLine("======================================");
            Console.WriteLine("           OPERATION HISTORY          ");
            Console.WriteLine("======================================");
            Console.WriteLine("1. View Operation History");
            Console.WriteLine("2. View Last Operation");
            Console.WriteLine("3. Remove Last Operation");
            Console.WriteLine("4. Simulate Student Action (Add/Update/Delete)");
            Console.WriteLine("5. Exit");
            Console.Write("\nEnter choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n======================================");
                    Console.WriteLine("           OPERATION HISTORY          ");
                    Console.WriteLine("======================================");
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("If there are no recorded operations, display an appropriate message.");
                    }
                    else
                    {
                        int index = 1;
                        // Stack enumerates from top to bottom
                        foreach (var op in operationHistory)
                        {
                            Console.WriteLine($"{index}. {op.Action} {op.StudentName} ({op.StudentNumber})");
                            index++;
                        }
                    }
                    break;

                case 2:
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("\nIf there are no recorded operations, display an appropriate message.");
                    }
                    else
                    {
                        Operation lastOp = operationHistory.Peek();
                        Console.WriteLine($"\nLast Operation: {lastOp.Action} {lastOp.StudentName} ({lastOp.StudentNumber})");
                    }
                    break;

                case 3:
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("\nIf there are no recorded operations, display an appropriate message.");
                    }
                    else
                    {
                        operationHistory.Pop();
                        Console.WriteLine("\nLast operation removed successfully!");
                    }
                    break;

                case 4:
                    // Helper option to push sample operations to test the Stack functionality
                    Console.WriteLine("\nChoose Action to Record:");
                    Console.WriteLine("1. Added Student");
                    Console.WriteLine("2. Updated Student");
                    Console.WriteLine("3. Deleted Student");
                    Console.Write("Enter sub-choice: ");
                    if (int.TryParse(Console.ReadLine(), out int subChoice))
                    {
                        Operation op = new Operation();
                        if (subChoice == 1) op.Action = "Added";
                        else if (subChoice == 2) op.Action = "Updated";
                        else if (subChoice == 3) op.Action = "Deleted";
                        else
                        {
                            Console.WriteLine("Invalid action.");
                            break;
                        }

                        Console.Write("Enter Student Number: ");
                        op.StudentNumber = Console.ReadLine();
                        Console.Write("Enter Student Name: ");
                        op.StudentName = Console.ReadLine();

                        operationHistory.Push(op);
                        Console.WriteLine("\nOperation recorded in stack successfully!");
                    }
                    break;

                case 5:
                    Console.WriteLine("\nProgram exited.");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice.");
                    break;
            }
            Console.WriteLine();
        } while (choice != 5);
    }
}