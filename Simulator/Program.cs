using Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Simulator
{
    public class Program
    {
        private static ISimulator Simulator;

        static List<MatchUp> GetMatchUps(IEnumerable<PlayerConfiguration> players)
        {
            List<MatchUp> matchUps = new();
            for (int x = 0; x < players.Count(); ++x)
            {
                for (int y = 0; y < players.Count(); ++y)
                {
                    if (x != y)
                    {
                        matchUps.Add(new MatchUp(players.ElementAt(x), players.ElementAt(y)));
                    }
                }
            }
            return matchUps;
        }

        static void Main(string[] args)
        {
            Simulator = new Simulator(new CardFactory());
            using var reader = XmlReader.Create(args.Any() ? args[0] : "configuration.xml");
            var conf = new XmlSerializer(typeof(SimulationConfiguration)).Deserialize(reader) as SimulationConfiguration;
            foreach (var p in conf.Players)
            {
                p.Id = Guid.NewGuid();
            }
            List<MatchUp> matchUps = GetMatchUps(conf.Players);
            var exceptions = new List<Exception>();
            for (int i = 0; i < 999999; ++i)
            {
                try
                {
                    Simulator.PlayRoundOfGames(conf, matchUps);
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                    System.IO.File.AppendAllText("exceptions.txt", e.ToString() + Environment.NewLine);
                }
            }
        }
    }
}
