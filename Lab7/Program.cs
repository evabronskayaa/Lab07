using System;
using System.IO;

namespace Lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            File.WriteAllText("input.txt", line);

            GetResult(line);
        }
        private static void GetResult(string line)
        {
            if (line != null)
            {
                string[] elements = line.Replace("  ", " ").Trim().Split(" ");

                string result;
                try
                {
                    double digit1 = Convert.ToDouble(elements[0]);
                    for (int i = 1; i < elements.Length - 1; i += 2)
                    {
                        string oper = elements[i];
                        double digit2 = Convert.ToDouble(elements[i + 1]);

                        digit1 = Calculate(digit1, digit2, oper);
                    }
                    result = Convert.ToString(digit1);
                }
                catch (Exception){
                    result = "Допущена ошибка в примере";
                }
                File.WriteAllText("output.txt", result);
            }
            else{
                Console.WriteLine("Пример отсутствует");
            }
        }
        private static double Calculate(double x, double y, string oper){
            switch (oper)
            {
                case "+":
                    return x + y;
                case "-":
                    return x - y;
                case "*":
                    return x * y;
                case "/":
                    if (y == 0) throw new Exception("Недопустимая операция");
                    return x / y;
                default:
                    throw new Exception("Недопустимая операция");
            }
        }
    }
}
