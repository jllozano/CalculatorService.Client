using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    case "mult": break;
                    case "div": break;
                    case "sqrt": break;
                    case "query": break;
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
