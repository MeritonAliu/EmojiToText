using System.Text.Json;

namespace EmojiToText;
public static class EmojiConverter
{
    private static Dictionary<string, string> emojiDictionary;
    static EmojiConverter()
    {
        string jsonFile = EmojiLoader.getJsonOffline();

        string json = File.ReadAllText(jsonFile);
        var emojiDictionaryFromJson = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json)!;

        emojiDictionary = new Dictionary<string, string>();
        foreach (var item in emojiDictionaryFromJson)
        {
            var emojiName = item.Value.GetProperty("name").GetString();
            emojiDictionary.Add(item.Key, emojiName!);
        }
    }
    public static string ToText(string input)
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));

        foreach (var emoji in emojiDictionary)
        {
            input = input.Replace(emoji.Key, emoji.Value);
        }
        return input;
    }

    public static string ToEmoji(string input)
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));

        foreach (var emoji in emojiDictionary)
        {
            input = input.Replace(emoji.Value, emoji.Key);
        }
        return input;
    }


    // NEW TO TEST
    public static bool IsSupported(string input)
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));

        return emojiDictionary.ContainsKey(input);
    }

    public static string RemoveEmojis(string input)
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));

        foreach (var emoji in emojiDictionary)
        {
            input = input.Replace(emoji.Key, "");
        }
        return input;
    }

    public static int CountEmojis(string input)
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));

        int count = 0;
        foreach (var emoji in emojiDictionary)
        {
            if (input.Contains(emoji.Key))
            {
                count++;
            }
        }
        return count;
    }

    public static string ExtractEmojis(string input)
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));

        var emojis = new List<string>();
        foreach (var emoji in emojiDictionary)
        {
            if (input.Contains(emoji.Key))
            {
                emojis.Add(emoji.Key);
            }
        }
        return string.Join(" ", emojis);
    }
    public static bool ContainsEmoji(string input)
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));

        foreach (var emoji in emojiDictionary)
        {
            if (input.Contains(emoji.Key))
            {
                return true;
            }
        }
        return false;
    }


    public static string AllEmojis()
    {
        return string.Join(" ", emojiDictionary.Keys);
    }
    public static string RandomEmoji()
    {
        return emojiDictionary.ElementAt(new Random().Next(0, emojiDictionary.Count)).Key;
    }
    public static string RandomEmojis(int count = 0)
    {
        return string.Join(" ", new Random().GetItems(emojiDictionary.Keys.ToArray(), count));
    }
}
