using System;

public static class Defaults
{
    // This is a read-only property.
    /// <summary>
    /// Returns the Deafults color for this game. to set value use SetColor(ConsoleColor color)
    /// </summary>
    public static ConsoleColor Color { get; private set; } = ConsoleColor.White;

    // Method to set the Color.
    public static ConsoleColor SetColor(ConsoleColor color) { Color = color; return Color; }
}