using System.Text.Json.Nodes;

namespace EmojiToText;

internal static class EmojiLoader
{
    private static readonly HttpClient httpClient = new HttpClient();
    private static readonly string url = "https://raw.githubusercontent.com/muan/unicode-emoji-json/refs/heads/main/data-by-emoji.json";

    internal static string getJsonOnline()
    {
        string localFile = Path.Combine(AppContext.BaseDirectory, "downloaded-data-by-emoji.json");

        try
        {
            string jsonContent = httpClient.GetStringAsync(url).Result;
            File.WriteAllText(localFile, jsonContent);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return localFile;
    }

    internal static string getJsonOffline()
    {
        string jsonData = Path.Combine(AppContext.BaseDirectory, "data-by-emoji.json");

        if (!File.Exists(jsonData))
        {
            jsonData = Path.Combine(AppContext.BaseDirectory, "contentFiles", "any", "any", "data-by-emoji.json");
        }

        if (!File.Exists(jsonData))
        {
            throw new FileNotFoundException("Could not find 'data-by-emoji.json'.");
        }

        return jsonData;
    }
}