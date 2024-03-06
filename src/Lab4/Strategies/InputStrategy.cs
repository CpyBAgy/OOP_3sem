using System;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Strategies;

public class InputStrategy : IInputStrategy
{
    public string Compile()
    {
        try
        {
            string? input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) Console.WriteLine("Error: Please enter a value.");
            }
            while (string.IsNullOrEmpty(input));
            return input;
        }
        catch (Exception ex)
        {
            throw new CustomCompilationException($"An unexpected error occurred in Compile: {ex.Message}", ex);
        }
    }
}
