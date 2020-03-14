using System;

namespace ET_7_8_Square_Fibonacci.Data
{
    public static class Parser
    {
        public static InputData ParseArgs(string[] args)
        {
            if (args == null)
            {
                throw new NullReferenceException("Array of parameters is null"); //81
            }
            if (args.Length < InputData.MinCountParams ||
                 args.Length > InputData.MaxCountParams)
            {
                throw new ArgumentException(
                    "The number of parameters is incorrect. " +
                    "There must be: " + InputData.MinCountParams + " " +
                    "or " + InputData.MaxCountParams);
            }

            if(args.Length == InputData.MaxCountParams)
            {
                return new InputData
                {
                    ProgramMode = InputData.Mode.Fibonacci,
                    StartFibonacciRange = Int32.Parse(args[0]),
                    EndFibonacciRange = Int32.Parse(args[1]),                   
                };
            }
            else
            {
                return new InputData
                {
                    ProgramMode = InputData.Mode.Square,
                    SquaryValue = Int32.Parse(args[0]),                
                };
            }

        }
    }
}
