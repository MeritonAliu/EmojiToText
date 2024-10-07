using System.Dynamic;

namespace EmojiToText;

public static class EmojiConverter
{
  private static Dictionary<string, string> emojiDictionary = new Dictionary<string, string>
  {
    {"😀","Grinning Face"},
    {"😃","Grinning Face with Big Eyes"},
    {"😄","Grinning Face with Smiling Eyes"},
    {"😁","Beaming Face with Smiling Eyes"}
  };

  public static string ToText(string input)
  {
    foreach (var emoji in emojiDictionary)
    {
      input = input.Replace(emoji.Key, emoji.Value);
    }
    return input;
  }

  public static string ToEmoji(string input)
  {
    foreach (var emoji in emojiDictionary)
    {
      input = input.Replace(emoji.Value, emoji.Key);
    }
    return input;
  }
}
