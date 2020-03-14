
namespace ET_7_8_Square_Fibonacci.Data
{
    public class InputData
    {
        public enum Mode
        {
            Square = 1,
            Fibonacci = 2
        }
        public Mode ProgramMode { get; set; }

        public int SquaryValue { get; set; }
        public int StartFibonacciRange { get; set; }
        public int EndFibonacciRange { get; set; }

        public const int MinCountParams = 1;
        public const int MaxCountParams = 2;
    }
}
