using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EmojiToText;

[MemoryDiagnoser]
[SimpleJob(warmupCount: 3, iterationCount: 10)]
public class EmojiConverterBenchmark
{
    private const string SingleEmoji = "😀";
    private const string SingleText = "grinning face";
    private static string MultipleEmoji = new string("😀"[0], 1000); // 1000 emoji characters
    private static string MultipleLarge = string.Concat(Enumerable.Repeat("grinning face ", 1000)); // 1000 repetitions of the same text


    [Benchmark]
    public string ConvertSingleEmojiToText()
    {
        return EmojiConverter.ToText(SingleEmoji); // Convert from emoji to text
    }

    [Benchmark]
    public string ConvertSingleTextToEmoji()
    {
        return EmojiConverter.ToEmoji(SingleText); // Convert from text to emoji
    }

    [Benchmark]
    public string ConvertMultipleEmojiToText()
    {
        return EmojiConverter.ToText(MultipleEmoji);
    }

    [Benchmark]
    public string ConvertMultipleTextToEmoji()
    {
        return EmojiConverter.ToEmoji(MultipleLarge);
    }
}
