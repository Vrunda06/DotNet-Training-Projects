using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator - .NET Console App");
            while (true)
            {
                Console.Write("Enter first number (or 'q' to quit): ");
                var a = Console.ReadLine();
                if (a == "q") break;
                Console.Write("Enter operator (+ - * /): ");
                var op = Console.ReadLine();
                Console.Write("Enter second number: ");
                var b = Console.ReadLine();
                try
                {
                    double x = double.Parse(a);
                    double y = double.Parse(b);
                    double result = op switch
                    {
                        "+" => x + y,
                        "-" => x - y,
                        "*" => x * y,
                        "/" => y == 0 ? double.NaN : x / y,
                        _ => double.NaN
                    };
                    Console.WriteLine($\"Result: {result}\\n\");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(\"Invalid input, try again. \" + ex.Message);
                }
            }
        }
    }
}
