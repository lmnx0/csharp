using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace functionsmethods
{
    internal class Program
    {
        static double EvaluateExpression(string expression)
        {
            string[] tokens = expression.Split(' ');

            Stack<double> values = new Stack<double>();
            Stack<char> operators = new Stack<char>();

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double number))
                {
                    values.Push(number);
                }
                else if (IsOperator(token))
                {
                    while (operators.Count > 0 && Precedence(operators.Peek()) >= Precedence(token[0]))
                    {
                        double b = values.Pop();
                        double a = values.Pop();
                        char op = operators.Pop();
                        double result = ApplyOperation(a, b, op);
                        values.Push(result);
                    }
                    operators.Push(token[0]);
                }
            }

            while (operators.Count > 0)
            {
                double b = values.Pop();
                double a = values.Pop();
                char op = operators.Pop();
                double result = ApplyOperation(a, b, op);
                values.Push(result);
            }

            return values.Peek();
        }

        static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        static int Precedence(char op)
        {
            if (op == '+' || op == '-')
                return 1;
            if (op == '*' || op == '/')
                return 2;
            return 0;
        }

        static double ApplyOperation(double a, double b, char op)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b != 0)
                    {
                        return a / b;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero!");
                        return double.NaN;
                    }
                default:
                    throw new InvalidOperationException("Invalid operator: " + op);
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Simple Calculator");
                Console.WriteLine("Enter an expression (e.g., '5 * 7 + 3') or 'exit' to quit: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting the calculator. Goodbye!");
                    break;
                }

                try
                {
                    double result = EvaluateExpression(input);
                    Console.WriteLine("Result: " + result);
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}
