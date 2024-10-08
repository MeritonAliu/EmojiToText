namespace EmojiToText;

internal static class EmojiLoader
{
    private static readonly HttpClient httpClient = new HttpClient();
    private static readonly string url = "https://raw.githubusercontent.com/muan/unicode-emoji-json/refs/heads/main/data-by-emoji.json";
    static EmojiLoader()
    {

    }

    internal static string DownloadJsonFromUrl()
    {
        string localFilePath = Path.Combine(AppContext.BaseDirectory, "downloaded-data-by-emoji.json");

        try
        {
            string jsonContent = httpClient.GetStringAsync(url).Result;
            File.WriteAllText(localFilePath, jsonContent);
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return localFilePath;
    }
}