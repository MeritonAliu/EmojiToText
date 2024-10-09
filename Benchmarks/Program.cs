using BenchmarkDotNet.Running;

class Program
{
    static void Main(string[] args)
    {
        // This will run all benchmarks in the specified class
        var summary = BenchmarkRunner.Run<EmojiConverterBenchmark>();
    }
}
