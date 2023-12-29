public static class GameSystem
{
    public static void Message(string text = "", ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }

    public static void Title(string text = "", ConsoleColor color = ConsoleColor.Red)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }
}