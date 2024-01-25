using System.Text.Json;

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

    public static void Gold(int gold)
    {
        Message(gold.ToString() + " Minurbiuns", ConsoleColor.DarkYellow);
    }

    public static void Save(object obj, string path)
    {
        string json = JsonSerializer.Serialize(obj, new JsonSerializerOptions{WriteIndented = true});

        File.WriteAllText(path, json);
    }

    public static void SavePlayer(Player player)
    {
        Save(player, "save.json");
    }
    
    public static T Load<T>(string path)
    {
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<T>(json);
        }
        else
            return default;
    }

    public static Player LoadPlayer()
    {
        return Load<Player>("save.json");
    }
}