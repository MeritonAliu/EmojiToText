# EmojiToText

## Features

- Convert emojis to descriptive text.
- convert text back into emojis.
- XUnit tests are implemented
- Wide range of emojis from the latest Unicode standart.

## Installation

Install the package via NuGet:

```bash
dotnet add package EmojiToText
```

> Or install it via Visual Studio NuGet package manager

## Usage

### Example usecases

- Accessibility: Convert emojis to text for screen readers, improving content accessibility.
- Text Processing: Enhance sentiment analysis or content moderation by converting emojis to readable text.
- Debugging: Simplify logs with emojis by converting them to descriptive text for easier analysis.

### Emoji to Text

```cs
using EmojiToText;

class Program
{
    static void Main(string[] args)
    {
        string input = "Hello 😀!";
        string result = EmojiConverter.ToText(input);
        Console.WriteLine(result);  // Output: Hello grinning face!
    }
}
```

### Text To Emoji

```cs
using EmojiToText;

class Program
{
    static void Main(string[] args)
    {
        string text = "grinning face";
        string emoji = EmojiConverter.ToEmoji(text);
        Console.WriteLine(emoji);  // Output: 😀
    }
}
```

## Running Tests

First clone the repository:

```bash
git clone https://github.com/MeritonAliu/EmojiToText.git
```

To run the tests for this project, use the following command:

```bash
dotnet test
```

## References

- [Emoji List](https://github.com/muan/unicode-emoji-json)
- [XUnit](https://xunit.net)

## Author

[@MeritonAliu](https://github.com/MeritonAliu) - 2024

## Contributing

Bug reports and contributions are welcome! Feel free to submit pull requests or file issues.

## License

- The main project is licensed under the [MIT License](LICENSE).
- Emoji data is governed by the [Unicode License](UNICODE_LICENSE).
