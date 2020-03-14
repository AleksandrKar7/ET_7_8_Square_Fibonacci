using ET_7_8_Square_Fibonacci.Data;
using ET_7_8_Square_Fibonacci.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET_7_8_Square_Fibonacci
{
    static class ConsoleMenu
    {
        public static void ShowConsoleMenu(string[] inputParams)
        {
            bool isNewTry = false;
            int result;

            do
            {
                if (isNewTry)
                {
                    result = AskMenuItem("Choose program mode",
                       new string[] { InputData.Mode.Square.ToString(),
                            InputData.Mode.Fibonacci.ToString() });

                    inputParams = AskInputParams((InputData.Mode)result);
                    isNewTry = false;
                }

                if (!Validator.IsValidArgs(inputParams))
                {
                    Console.WriteLine("Your data is not valid");
                    if (!AskBoolValue("Do you want to retype them?",
                        new string[] { "YES", "Y" }))
                    {
                        break;
                    }

                    result = AskMenuItem("Choose program mode",
                        new string[] { InputData.Mode.Square.ToString(),
                            InputData.Mode.Fibonacci.ToString() });

                    inputParams = AskInputParams((InputData.Mode)result);

                    continue;
                }

                InputData inputData = Parser.ParseArgs(inputParams);

                switch (inputData.ProgramMode)
                {
                    case InputData.Mode.Square:
                        ISquareSeriesFinder square =
                            new MathFinder();
                        int[] squareSeries = square.GetSquareSeries(
                            inputData.SquaryValue);
                        PrintArray("Square series: ", squareSeries);
                        break;

                    case InputData.Mode.Fibonacci:
                        IFibonacciSeriesMaker fibonacci =
                            new MathFinder();
                        int[] fibonacciSeries = fibonacci.GetFibonacciSeries(
                            inputData.StartFibonacciRange, 
                            inputData.EndFibonacciRange);
                            PrintArray("Fibonacci series: ", fibonacciSeries);
                        break;
                }


                if (AskBoolValue("Do you want to continue?",
                    new string[] { "YES", "Y" }))
                {
                    isNewTry = true;
                }
                else
                {
                    break;
                }
            } while (true);
        }

        private static void PrintArray(string message, string[] arr)
        {
            Console.WriteLine(message);
            foreach (string item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintArray(string message, int[] arr)
        {
            Console.WriteLine(message);
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static string[] AskInputParams(InputData.Mode mode)
        {
            string[] result;
            if(mode == InputData.Mode.Square)
            {
                result = new string[InputData.MinCountParams];
                Console.WriteLine("Enter the end of range: ");
                result[0] = Console.ReadLine();

                return result;
            }
            if (mode == InputData.Mode.Fibonacci)
            {
                result = new string[InputData.MaxCountParams];
                Console.WriteLine("Enter the start of fibonacci series: ");
                result[0] = Console.ReadLine();
                Console.WriteLine("Enter the end of fibonacci series: ");
                result[1] = Console.ReadLine();

                return result;
            }

            throw new InvalidOperationException("Unsupported InputData.Mode");
        }

        public static int AskMenuItem(string message, string[] menuItems)
        {
            int i = 1;
            int result;
            Console.WriteLine(message);
            foreach (string item in menuItems)
            {
                Console.WriteLine(i + " - " + item);
                i++;
            }

            do
            {
                Int32.TryParse(Console.ReadLine(), out result);
                if (result >= 1 && result <= menuItems.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong item. Choose again");
                }
            } while (true);

            return result;
        }

        public static bool? AskBoolValue(string message)
        {
            string text;
            string insturction;
            string[] trueArray = { "T", "TRUE" };
            string[] falseArray = { "F", "FALSE" };

            insturction = String.Format("For true: {0}; For false: '{1}'",
                String.Join("', ", trueArray), String.Join("', ", falseArray));

            Console.WriteLine(message);
            Console.WriteLine(insturction);

            text = Console.ReadLine();
            text.Trim();
            text = text.ToUpper();

            if (text == null)
            {
                return null;
            }

            if (trueArray.Contains(text))
            {
                return true;
            }
            if (falseArray.Contains(text))
            {
                return false;
            }

            return null;
        }

        public static bool AskBoolValue(string message, string[] trueArray)
        {
            if (trueArray == null)
            {
                return false;
            }
            string text;
            string insturction;


            insturction = String.Format("For true: {0}; For false: '{1}'",
                String.Join("', ", trueArray), "Press enter");

            Console.WriteLine(message);
            Console.WriteLine(insturction);

            text = Console.ReadLine();
            text.Trim();
            text = text.ToUpper();

            if (text == null)
            {
                return false;
            }

            if (trueArray.Contains(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool? AskBoolValue(string message, string[] trueArray, string[] falseArray)
        {
            if (trueArray == null)
            {
                return null;
            }
            if (falseArray == null)
            {
                return null;
            }
            string text;
            string insturction;

            insturction = String.Format("For agree: {0}; For disagree: '{1}'",
                String.Join("', ", trueArray), String.Join("', ", falseArray));

            Console.WriteLine(message);
            Console.WriteLine(insturction);

            text = Console.ReadLine();
            text.Trim();
            text = text.ToUpper();

            if (text == null)
            {
                return null;
            }
            if (trueArray.Contains(text))
            {
                return true;
            }
            if (falseArray.Contains(text))
            {
                return false;
            }

            return null;
        }
    }
}
