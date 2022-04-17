using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Simulator
{
    [XmlRoot("configuration")]
    public class SimulationConfiguration
    {
        [XmlElement("simulation_depth")]
        public int SimulationDepth { get; set; }

        [XmlArray("players")]
        [XmlArrayItem("player")]
        public PlayerConfiguration[] Players { get; set; }
    }

    public class PlayerConfiguration
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("deck_path")]
        public string DeckPath { get; set; }

        [XmlIgnore]
        public Guid Id { get; set; }

        [XmlIgnore]
        public Dictionary<string, Tuple<int, int>> UsedCards { get; set; } = new();

        [XmlIgnore]
        public int Wins { get; set; }

        [XmlIgnore]
        public int Losses { get; set; }

        public override string ToString()
        {
            return $"{Name} wins: {Wins} losses {Losses} winrate: {Simulator.GetWinrate(Wins, Losses)}";
        }
    }

    public class MatchUp
    {
        public MatchUp(PlayerConfiguration startingPlayer, PlayerConfiguration opponent)
        {
            StartingPlayer = startingPlayer;
            Opponent = opponent;
        }

        public PlayerConfiguration StartingPlayer { get; }

        public PlayerConfiguration Opponent { get; }

        public IEnumerable<PlayerConfiguration> Players => new List<PlayerConfiguration> { StartingPlayer, Opponent };
    }
}
