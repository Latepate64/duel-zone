namespace Web
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class Card
    {
        public Card(string? name, int manaCost, string? civilization, string? rulesText)
        {
            Name = name;
            ManaCost = manaCost;
            Civilization = civilization;
            RulesText = rulesText;
        }

        public string? Name { get; set; }
        public int ManaCost { get; set; }
        public string? Civilization { get; set; }
        public string? RulesText { get; set; }
    }
}