using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {

        //calc.exe 5 6 7 * + 1 - 
        static void Main(string[] args)
        {
            Stack<int> values = new Stack<int>();


            args = Console.ReadLine().Split(' ');

            foreach (string token in args)
            {
                int value;
                if(int.TryParse(token, out value))
                {
                    values.Push(value);
                }
                else
                {
                    int rhs = values.Pop();
                    int lhs = values.Pop();

                    switch (token)
                    {
                        case "+":
                            values.Push(lhs + rhs);
                            break;
                        case "-":
                            values.Push(lhs - rhs);
                            break;
                        case "*":
                            values.Push(lhs * rhs);
                            break;
                        case "/":
                            values.Push(lhs / rhs);
                            break;
                        case "%":
                            values.Push(lhs % rhs);
                            break;
                        default:
                            throw new ArgumentException($"Unrecognized token {token}");
                    }
                }
            }

            Console.WriteLine(values.Pop());
        }
    }
}
