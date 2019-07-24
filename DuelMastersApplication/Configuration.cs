namespace DuelMastersApplication
{
    public class Configuration
    {
        public PlayerConfiguration Player1Configuration { get; set; }
        public PlayerConfiguration Player2Configuration { get; set; }
        public int WhoGoesFirst { get; set; }
        public bool FetchJsonOnline { get; set; }
        public string JsonUrlOrPath { get; set; }
    }

    public class PlayerConfiguration
    {
        public string Name { get; set; }
        public string DeckPath { get; set; }
        public bool ControlledByComputer { get; set; }
    }
}
