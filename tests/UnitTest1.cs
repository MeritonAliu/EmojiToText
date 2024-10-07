namespace EmojiToText.Tests;

public class EmojiConverterTests
{
    [Fact]
    public void EmojiToText()
    {
        string input = "😀";
        string expected = "grinning face";

        string result = EmojiConverter.ToText(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TextToEmoji()
    {
        string input = "grinning face";
        string expected = "😀";

        string result = EmojiConverter.ToEmoji(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TextToText_SameTextReturn()
    {
        var input = "this is not an emoji text!";
        string expected = "this is not an emoji text!";

        string result = EmojiConverter.ToText(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TextToEmoji_SameTextReturn()
    {
        var input = "this is not an emoji text!";
        string expected = "this is not an emoji text!";

        string result = EmojiConverter.ToEmoji(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TextToText_EmptyInput()
    {
        var input = "";
        var expectedOutput = "";

        var result = EmojiConverter.ToText(input);
        Assert.Equal(expectedOutput, result);
    }

    [Fact]
    public void TextToEmoji_EmptyInput()
    {
        var input = "";
        var expectedOutput = "";

        var result = EmojiConverter.ToEmoji(input);
        Assert.Equal(expectedOutput, result);
    }

    [Fact]
    public void TextToEmoji_NullInput()
    {
        string? input = null;

        Assert.Throws<ArgumentNullException>(() => EmojiConverter.ToEmoji(input!));
    }

    [Fact]
    public void EmojiToText_NullInput()
    {
        string? input = null;

        Assert.Throws<ArgumentNullException>(() => EmojiConverter.ToText(input!));
    }
}