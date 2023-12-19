using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;

[MemoryDiagnoser]
public class SwitchBenchmark
{


    [Benchmark]
    public string RunSwitchExpressions()
    {

        string result = "";
        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            int number = random.Next(0, 101);

             result = number switch
            {
                _ when (number < 0) => "Less than 0",
                _ when ((number >= 0 && number < 10) && number % 2 == 0) => "Between 0 and 10 (exclusive) and even",
                _ when ((number >= 10 && number < 20) && number % 2 == 0) => "Between 10 and 20 (exclusive) and even",
                _ when ((number >= 20 && number < 30) && number % 2 == 0) => "Between 20 and 30 (exclusive) and even",
                _ when ((number >= 30 && number < 40) && number % 2 == 0) => "Between 30 and 40 (exclusive) and even",
                _ when ((number >= 40 && number < 50) && number % 2 == 0) => "Between 40 and 50 (exclusive) and even",
                _ when ((number >= 50 && number < 60) && number % 2 == 0) => "Between 50 and 60 (exclusive) and even",
                60 => "Equal to 60",
                _ when (number % 2 == 0) => "Greater than 60 and Even",
                _ when (number % 2 != 0) => "Greater than 60 and Odd",
                _ => "Other cases"
            };
            
        }
        return result;
    }

    [Benchmark]
    public string RunSwitchCase()
    {
        string result2 = "";
        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            int number2 = random.Next(0, 101);

            switch (number2)
            {
                case int n when n < 0:
                    result2 = "Less than 0";
                    break;
                case int n when n >= 0 && n < 10 && n % 2 == 0:
                    result2 = "Between 0 and 10 (exclusive) and even";
                    break;
                case int n when n >= 10 && n < 20 && n % 2 == 0:
                    result2 = "Between 10 and 20 (exclusive) and even";
                    break;
                case int n when n >= 20 && n < 30 && n % 2 == 0:
                    result2 = "Between 20 and 30 (exclusive) and even";
                    break;
                case int n when n >= 30 && n < 40 && n % 2 == 0:
                    result2 = "Between 30 and 40 (exclusive) and even";
                    break;
                case int n when n >= 40 && n < 50 && n % 2 == 0:
                    result2 = "Between 40 and 50 (exclusive) and even";
                    break;
                case int n when n >= 50 && n < 60 && n % 2 == 0:
                    result2 = "Between 50 and 60 (exclusive) and even";
                    break;
                case 60:
                    result2 = "Equal to 60";
                    break;
                case int n when n % 2 == 0:
                    result2 = "Greater than 60 and Even";
                    break;
                case int n when n % 2 != 0:
                    result2 = "Greater than 60 and Odd";
                    break;
                default:
                    result2 = "Other cases";
                    break;
            }


        }

        return result2;
    }


    static void Main()
    {
        var config = ManualConfig.Create(DefaultConfig.Instance)
    .AddDiagnoser(MemoryDiagnoser.Default);
        _ = BenchmarkRunner.Run<SwitchBenchmark>(config);

    }
}
