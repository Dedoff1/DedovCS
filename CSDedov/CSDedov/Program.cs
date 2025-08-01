using System;
using System.Linq;

/*Task 
Make up an algorithm 
If the entered number is greater than 7, then print “Hello” 
If the entered name matches “John”, then output “Hello, John”, if not, then output "There is no such name" 
There is a numeric array at the input, it is necessary to output array elements that are multiples of 3 
*/


namespace CSDedov
{
    internal class Program
    {
        static void AnalyzeInput(object EnterValue)
        {
            switch (EnterValue)
            {
                case int EnterNum:
                    Console.WriteLine(EnterNum > 7 ? "Hello" : "Number is 7 or below");
                    break;
                case int[] EnterArray:
                    Console.WriteLine("Array elements that are multiples of 3: " + string.Join(", ", EnterArray.Where(n => n % 3 == 0)));
                    break;
                case string EnterString when int.TryParse(EnterString, out int EnterStringNum):
                    Console.WriteLine(EnterStringNum > 7 ? "Hello" : "Number is 7 or below");
                    break;
                case string EnterString when EnterString.StartsWith("[") & EnterString.EndsWith("]"):
                    try
                    {
                        var EnterStringArray = EnterString.Trim('[', ']').Split(',').Select(array => int.Parse(array.Trim())).ToArray();
                        Console.WriteLine("Array elements that are multiples of 3: " + string.Join(", ", EnterStringArray.Where(n => n % 3 == 0)));
                    }
                    catch
                    {
                        Console.WriteLine("Try array of numbers");
                    }
                    break;
                case string EnterName:
                    Console.WriteLine(EnterName.Equals("John") ? "Hello, John" : "There is no such name");
                    break;
                default:
                    Console.WriteLine("Check your input");
                    break;
            }
        }
        static void Main(string[] args)
        {

            AnalyzeInput(2);
            AnalyzeInput(8);
            AnalyzeInput("Arya");
            AnalyzeInput("John");
            AnalyzeInput(new int[] { 1, 3, 7, 9, 4 });
            AnalyzeInput("2");
            AnalyzeInput("8");
            AnalyzeInput("[3, 2, 9, 21, 8]");
            AnalyzeInput("[Jimmy, Mike, Kim, Howard, Chuck]");
            AnalyzeInput(new string[] { "Jon", "Robb", "Bran", "Theon", "Sansa" });

           
            while (true)
            {
                Console.WriteLine("Awaiting input...(type 'exit' to quit)");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    continue;
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;
                AnalyzeInput(input);
                
            }
            Console.WriteLine("Program terminated");

            Console.ReadLine();
        }
    }
}