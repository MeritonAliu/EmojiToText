# EmojiToText

[![.NET](https://github.com/MeritonAliu/EmojiToText/actions/workflows/dotnet.yml/badge.svg)](https://github.com/MeritonAliu/EmojiToText/actions/workflows/dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/EmojiToText.svg)](https://www.nuget.org/packages/EmojiToText/)
[![Nuget](https://img.shields.io/nuget/dt/EmojiToText)](https://www.nuget.org/packages/EmojiToText/)
[![License](https://img.shields.io/github/license/MeritonAliu/EmojiToText)](LICENSE)


## Features

- Convert emojis to descriptive text.
- Convert text back into emojis.
- XUnit tests are implemented
- Supports the latest Unicode version 16.0

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

## Roadmap

The roadmap can be fount at: [ROADMAP](ROADMAP.md)

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
