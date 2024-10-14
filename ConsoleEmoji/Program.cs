// See https://aka.ms/new-console-template for more information
using EmojiToText;

string input = "Hello 😀!";
string result = EmojiConverter.ToText(input);
Console.WriteLine(result);  // Output: Hello grinning face!
Console.WriteLine(EmojiConverter.jsonData);
Console.WriteLine("===============================================================");  