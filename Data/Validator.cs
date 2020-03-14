using System;

namespace ET_7_8_Square_Fibonacci.Data
{
    public static class Validator
    {
        public static bool IsValidArgs(string[] args)
        {
            if (args == null)
            {
                return false;
            }
            if (args.Length > InputData.MaxCountParams ||
                args.Length < InputData.MinCountParams)
            {
                return false;
            }

            int temp;
            for (int i = 0; i < args.Length; i++)
            {
                if (Int32.TryParse(args[i], out temp))
                {
                    if (temp < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
