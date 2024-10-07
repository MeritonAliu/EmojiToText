using System.Dynamic;
using System.Text.Json;
using System.IO;

namespace EmojiToText;

public static class EmojiConverter
{
    private static Dictionary<string, string> emojiDictionary;

    static EmojiConverter()
    {
        string jsonFilePath = Path.Combine(AppContext.BaseDirectory, "data-by-emoji.json");

        if (!File.Exists(jsonFilePath))
        {
            throw new FileNotFoundException($"Could not find file '{jsonFilePath}'.");
        }

        string json = File.ReadAllText(jsonFilePath);
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
}
