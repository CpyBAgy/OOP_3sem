using System;
using System.IO;
using Crayon;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class DisplayDriver : IDisplayDriver
{
    private readonly string _filePath;
    private CrayonColor _crayonColor = new CrayonColor(255, 255, 255);

    public DisplayDriver(string? filePath)
    {
        _filePath = filePath ?? string.Empty;
    }

    public void Clear()
    {
        Console.Clear();
        File.WriteAllText(_filePath, string.Empty);
    }

    public void SetColor(CrayonColor color)
    {
        _crayonColor = color;
    }

    public void Write(string text)
    {
        string formattedText = $"[Color:{_crayonColor.R},{_crayonColor.G},{_crayonColor.B}] {text}";
        File.AppendAllText(_filePath, formattedText);
        Console.WriteLine(Output.Rgb(_crayonColor.R, _crayonColor.G, _crayonColor.B).Text(formattedText));
    }
}
