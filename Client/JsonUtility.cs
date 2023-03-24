using System.Text.Json;

namespace TimerConsole
{
    internal class JsonUtility
    {
        internal static T Deserialize<T>(string jsonString)
        {
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
public class Rootobject
{
    public string schema { get; set; }
    public Card[] cards { get; set; }
}

public class Card
{
    public string[] civilizations { get; set; }
    public int cost { get; set; }
    public string name { get; set; }
    public Printing[] printings { get; set; }
    public string text { get; set; }
    public string type { get; set; }
    public string power { get; set; }
    public string[] subtypes { get; set; }
    public string[] supertypes { get; set; }
}

public class Printing
{
    public string set { get; set; }
    public string id { get; set; }
    public string rarity { get; set; }
    public string illustrator { get; set; }
    public string flavor { get; set; }
    public string image { get; set; }
}

