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
        // Use this if your console does not support UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

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
        // Use this if your console does not support UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

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

## Benchmarks

The following benchmarks apply to the current EmojiConverter methods.
The mutlitple benchmarks are done with 1000 emojis/texts.

| Method                     | Mean      | Error    | StdDev   | Allocated |
|--------------------------- |----------:|---------:|---------:|----------:|
| ConvertSingleEmojiToText   |  21.01 us | 0.240 us | 0.159 us |      48 B |
| ConvertSingleTextToEmoji   |  17.22 us | 0.131 us | 0.069 us |      32 B |
| ConvertMultipleEmojiToText |  98.05 us | 1.621 us | 1.072 us |         - |
| ConvertMultipleTextToEmoji | 334.73 us | 4.885 us | 3.231 us |    6025 B |

If you want to benchmark it yourself, clone the repo and use:

```bash
dotnet run --project Benchmarks -c Release
or 
dotnet run --project Benchmark/EmojiToText.Benchmarks.csproj -c Release
```

## References

- [Emoji List](https://github.com/muan/unicode-emoji-json)
- [XUnit](https://xunit.net)
- [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)

## Author

[@MeritonAliu](https://github.com/MeritonAliu) - 2024

## Contributing

Bug reports and contributions are welcome! Feel free to submit pull requests or file issues.

## License

- The main project is licensed under the [MIT License](LICENSE).
- Emoji data is governed by the [Unicode License](LICENSE_UNICODE).

## Donation

If you want to support me and my work, feel free to donate a coffee

[![Buy me a coffee](https://img.buymeacoffee.com/button-api/?text=Buy%20me%20a%20coffee&emoji=&slug=meritonaluiu&button_colour=FFDD00&font_colour=000000&font_family=Cookie&outline_colour=000000&coffee_colour=ffffff)](https://www.buymeacoffee.com/meritonaluiu)
