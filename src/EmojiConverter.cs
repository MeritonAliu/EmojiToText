using System.Text.Json;

namespace EmojiToText;

public static class EmojiConverter
{
    private static Dictionary<string, string> emojiDictionary;
    private static readonly HttpClient httpClient = new HttpClient();
    private static readonly string url = "https://raw.githubusercontent.com/muan/unicode-emoji-json/refs/heads/main/data-by-emoji.json";
    static EmojiConverter()
    {
        string jsonFilePath = Path.Combine(AppContext.BaseDirectory, "data-by-emoji.json");

        if (!File.Exists(jsonFilePath))
        {

            jsonFilePath = DownloadJsonFromUrl(url);
        }
        if (!File.Exists(jsonFilePath))
        {
            throw new FileNotFoundException($"Could not find file '{jsonFilePath}' from url ${url}.");
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
    private static string DownloadJsonFromUrl(string url)
    {
        string localFilePath = Path.Combine(AppContext.BaseDirectory, "downloaded-data-by-emoji.json");

        try
        {
            string jsonContent = httpClient.GetStringAsync(url).Result;
            File.WriteAllText(localFilePath, jsonContent);
            Console.WriteLine("File downloaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error downloading the file: {ex.Message}");
            return "";
        }

        return localFilePath;
    }
}
