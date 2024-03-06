namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface IDisplayDriver
{
    void Clear();
    void SetColor(CrayonColor color);
    void Write(string text);
}
