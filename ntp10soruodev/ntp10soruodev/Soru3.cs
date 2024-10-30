using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntp10soruodev
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Soru3
    {
        static void Main()
        {
            Console.WriteLine("Bir matematiksel ifade girin (örn. 3 + 4 * 2 / (1 - 5) ^ 2 ^ 3):");
            string ifade = Console.ReadLine();

            try
            {
                List<string> postfix = InfixToPostfix(ifade);
                Console.WriteLine("\nPostfix Notasyon: " + string.Join(" ", postfix));
                double sonuc = EvaluatePostfix(postfix);
                Console.WriteLine($"\nSonuç: {sonuc}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
            }
        }

        static List<string> InfixToPostfix(string ifade)
        {
            Stack<string> operatorStack = new Stack<string>();
            List<string> output = new List<string>();
            Dictionary<string, int> precedence = new Dictionary<string, int> { { "^", 4 }, { "*", 3 }, { "/", 3 }, { "+", 2 }, { "-", 2 } };
            Dictionary<string, bool> rightAssociative = new Dictionary<string, bool> { { "^", true }, { "*", false }, { "/", false }, { "+", false }, { "-", false } };

            string pattern = @"(\d+(\.\d+)?)|[\+\-\*/\^\(\)]";
            foreach (Match match in Regex.Matches(ifade, pattern))
            {
                string token = match.Value;

                if (double.TryParse(token, out _))
                {
                    output.Add(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorStack.Peek() != "(")
                    {
                        output.Add(operatorStack.Pop());
                    }
                    operatorStack.Pop();
                }
                else
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(" &&
                           ((rightAssociative.ContainsKey(token) && !rightAssociative[token] && precedence[token] <= precedence[operatorStack.Peek()]) ||
                           (rightAssociative.ContainsKey(token) && rightAssociative[token] && precedence[token] < precedence[operatorStack.Peek()])))
                    {
                        output.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }

            while (operatorStack.Count > 0)
            {
                output.Add(operatorStack.Pop());
            }

            return output;
        }

        static double EvaluatePostfix(List<string> postfix)
        {
            Stack<double> stack = new Stack<double>();
            Dictionary<string, Func<double, double, double>> operations = new Dictionary<string, Func<double, double, double>>
        {
            { "+", (a, b) => a + b },
            { "-", (a, b) => a - b },
            { "*", (a, b) => a * b },
            { "/", (a, b) => a / b },
            { "^", (a, b) => Math.Pow(a, b) }
        };

            Console.WriteLine("\nİşlem Adımları:");
            foreach (string token in postfix)
            {
                if (double.TryParse(token, out double num))
                {
                    stack.Push(num);
                }
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    double sonuc = operations[token](a, b);
                    stack.Push(sonuc);
                    Console.WriteLine($"{a} {token} {b} = {sonuc}");
                }
            }

            return stack.Pop();
        }
    }
}
