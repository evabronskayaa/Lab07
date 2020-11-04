using System;
using System.IO;

namespace Lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = GetPath();
            FileInfo input = new FileInfo(path);
            if (!input.Exists) { 
                input.Create();
                Console.WriteLine("Файл создан. Введите пример");
            }

            string line = Console.ReadLine();
            if (line.Length != 0)
            {
                string[] elements = WriteToFile(path, line).Trim().Split(" ");

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

                } catch (Exception){
                    result = "Допущена ошибка в примере";
                }
                string path2 = GetPath("output.txt");
                File.WriteAllText(path2, result);
            }
            else{
                Console.WriteLine("Пример отсутствует");
            }
        }
        private static string GetPath(string path = "input.txt")
        {
            string filePath = Environment.CurrentDirectory;
            filePath = @filePath.Substring(0, filePath.IndexOf("bin")) + path;
            return filePath;
        }
        private static string WriteToFile(string path, string line)
        {
            StreamWriter writer = new StreamWriter(path, false, System.Text.Encoding.Default);
            writer.WriteLine(line);
            writer.Close();

            while (line.Contains("  "))
                line = line.Replace("  ", " ");

            return line;
        }
        private static double Calculate(double x, double y, string oper)
        {
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