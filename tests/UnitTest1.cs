using Xunit;
using EmojiToText;


namespace EmojiToText.Tests;

public class EmojiToText
{
    [Fact]
    public void FirstEmoji()
    {
        string input = "😀";
        string expected = "grinning face";

        string result = EmojiConverter.ToText(input);
        Assert.Equal(expected, result);
    }
}

public class TextToEmoji
{
    [Fact]
    public void FirstEmoji()
    {
        string input = "grinning face";
        string expected = "😀";

        string result = EmojiConverter.ToEmoji(input);
        Assert.Equal(expected, result);
    }
}