using System.Text.Json;

namespace EmojiToText;
public static class EmojiConverter
{
    private static Dictionary<string, string> emojiDictionary;
    public static string jsonData;
    static EmojiConverter()
    {
        //var jsonData = EmojiLoader.DownloadJsonFromUrl();
        //var jsonData = Path.Combine(AppContext.BaseDirectory, "data-by-emoji.json");
        //var jsonData = Path.Combine(AppContext.BaseDirectory, "contentFiles", "any", "any", "data-by-emoji.json");

        jsonData = Path.Combine(AppContext.BaseDirectory, "contentFiles", "any", "any", "data-by-emoji.json");

        // Check if the file exists in the NuGet-installed location
        if (!File.Exists(jsonData))
        {
            // If not found, try looking in the base directory (for development environment)
            jsonData = Path.Combine(AppContext.BaseDirectory, "data-by-emoji.json");
        }

        // If still not found, throw an error or handle accordingly
        if (!File.Exists(jsonData))
        {
            throw new FileNotFoundException("Could not find 'data-by-emoji.json' in the expected locations.");
        }


        string json = File.ReadAllText(jsonData);
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
