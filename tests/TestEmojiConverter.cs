using BenchmarkDotNet.Filters;

namespace EmojiToText.Tests;

public class TestEmojiConverterTests
{
    [Fact]
    public void TestEmojiToText()
    {
        string input = "😀";
        string expected = "grinning face";

        string result = EmojiConverter.ToText(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestTextToEmoji()
    {
        string input = "grinning face";
        string expected = "😀";

        string result = EmojiConverter.ToEmoji(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestTextToText_SameTextReturn()
    {
        var input = "this is not an emoji text!";
        string expected = "this is not an emoji text!";

        string result = EmojiConverter.ToText(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestTextToEmoji_SameTextReturn()
    {
        var input = "this is not an emoji text!";
        string expected = "this is not an emoji text!";

        string result = EmojiConverter.ToEmoji(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestTextToText_EmptyInput()
    {
        var input = "";
        var expectedOutput = "";

        var result = EmojiConverter.ToText(input);
        Assert.Equal(expectedOutput, result);
    }

    [Fact]
    public void TestTextToEmoji_EmptyInput()
    {
        var input = "";
        var expectedOutput = "";

        var result = EmojiConverter.ToEmoji(input);
        Assert.Equal(expectedOutput, result);
    }

    [Fact]
    public void TestTextToEmoji_NullInput()
    {
        string? input = null;

        Assert.Throws<ArgumentNullException>(() => EmojiConverter.ToEmoji(input!));
    }

    [Fact]
    public void TestEmojiToText_NullInput()
    {
        string? input = null;

        Assert.Throws<ArgumentNullException>(() => EmojiConverter.ToText(input!));
    }

    [Fact]
    public void TestIsSupported()
    {
        string input = "😀";
        bool expected = true;

        bool result = EmojiConverter.IsSupported(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestRemoveEmojis()
    {
        string input = "Start😀Before😀After😀End";
        string expected = "StartBeforeAfterEnd";

        string result = EmojiConverter.RemoveEmojis(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestCountEmojis()
    {
        string input = "😀ha😀ha😀";
        int expected = 3;

        int result = EmojiConverter.CountEmojis(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestCountEmojis_EmptyInput()
    {
        string input = "";
        int expected = 0;

        int result = EmojiConverter.CountEmojis(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestExtractEmojis()
    {
        string input = "😀ha😀ha😀";
        string[] expected = { "😀", "😀", "😀" };

        string[] result = EmojiConverter.ExtractEmojis(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestExtractEmojis_EmptyInput()
    {
        string input = "";
        string[] expected = Array.Empty<string>();

        string[] result = EmojiConverter.ExtractEmojis(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestExtractEmojis_NoEmojis()
    {
        string input = "no emojis here!";
        string[] expected = Array.Empty<string>();

        string[] result = EmojiConverter.ExtractEmojis(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestContainsEmoji()
    {
        string input = "😀ha😀ha😀";
        bool expected = true;

        bool result = EmojiConverter.ContainsEmoji(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestContainsEmoji_EmptyInput()
    {
        string input = "";
        bool expected = false;

        bool result = EmojiConverter.ContainsEmoji(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestContainsEmoji_NoEmojis()
    {
        string input = "no emojis here!";
        bool expected = false;

        bool result = EmojiConverter.ContainsEmoji(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestAllEmojis()
    {
        var emojis = EmojiConverter.AllEmojis();
        var expected = EmojiConverter.GetDictionary().Keys;

        foreach (var emoji in expected)
        {
            Assert.Contains(emoji, emojis);
        }
    }

    [Fact]
    public void TestRandomEmoji()
    {
        var emoji = EmojiConverter.RandomEmoji();
        var emojis = EmojiConverter.GetDictionary().Keys;

        Assert.Contains(emoji, emojis);
    }

    [Fact]
    public void TestRandomEmojis()
    {
        var emojis = EmojiConverter.RandomEmojis(5);
        var allEmojis = EmojiConverter.GetDictionary().Keys.ToList();

        Assert.Equal(5, EmojiConverter.CountEmojis(emojis)); // Now that there are no spaces, Length matches the emoji count

        foreach (var emoji in EmojiConverter.GetDictionary().Keys)
        {
            if (emojis.Contains(emoji))
            {
                Assert.Contains(emoji, allEmojis);
            }
        }
    }

    [Fact]
    public void TestRandomEmojis_EmptyInput()
    {
        var emojis = EmojiConverter.RandomEmojis(0);
        var expected = "";

        Assert.Equal(expected, emojis);
    }
}