using System;

namespace CalculatorService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, introduce a command: add | sub | mult | div | sqrt | query");
            Console.Write(">>");

            string command = Console.ReadLine();

            while (!command.ToLower().Equals("exit"))
            {
                switch (command)
                {
                    case "add":
                        Console.WriteLine(CalculatorService.testAdd());                        
                        break;
                    case "sub":
                        Console.WriteLine(CalculatorService.testSub());
                        break;
                    case "mult": 
                        Console.WriteLine(CalculatorService.testMult());
                        break;
                    case "div": break;
                    case "sqrt": break;
                    case "query": 
                        Console.WriteLine(CalculatorService.testQuery());
                        break;
                    default:
                        Console.WriteLine("Invalid command. Try: add | sub | mult | div | sqrt | query");
                        break;
                }

                Console.Write(">>");
                command = Console.ReadLine();
            }
        }
    }
}
