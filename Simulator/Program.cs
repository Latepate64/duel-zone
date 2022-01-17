using DuelMastersCards;
using DuelMastersModels;
using DuelMastersModels.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Simulator
{
    public class Program
    {
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
            var simulator = new Simulator();

            using var reader = XmlReader.Create(args[0]);
            var conf = new XmlSerializer(typeof(SimulationConfiguration)).Deserialize(reader) as SimulationConfiguration;
            foreach (var p in conf.Players)
            {
                p.Id = Guid.NewGuid();
            }
            List<MatchUp> matchUps = GetMatchUps(conf.Players);
            for (int i = 0; i < 999999; ++i)
            {
                PlayRoundOfGames(simulator, conf, matchUps);
            }
        }

        private static void PlayGame(MatchUp matchUp, Simulator simulator, int simulationDepth)
        {
            using Player player1 = new SimulationPlayer { Name = matchUp.StartingPlayer.Name }, player2 = new SimulationPlayer { Name = matchUp.Opponent.Name };
            player1.Deck = new(GetCards(player1.Id, matchUp.StartingPlayer.DeckPath));
            player2.Deck = new(GetCards(player2.Id, matchUp.Opponent.DeckPath));
            using var duel = simulator.PlayDuel(player1, player2, simulationDepth);

            var usedCards = duel.Turns.SelectMany(x => x.Steps).SelectMany(x => x.UsedCards);
            if (duel.Winner != null)
            {
                UpdateWinnerUsedCards(duel, usedCards, matchUp.Players.Distinct().Single(x => x.Name == duel.Winner.Name));
            }
            foreach (var loser in duel.Losers)
            {
                UpdateLoserUsedCards(duel, usedCards, loser, matchUp.Players.Distinct().Single(x => x.Name == loser.Name));
            }
        }

        private static void UpdateWinnerUsedCards(Duel duel, IEnumerable<Card> usedCards, PlayerConfiguration winner)
        {
            ++winner.Wins;
            foreach (string cardName in usedCards.Where(x => duel.GetOwner(x) == duel.Winner).Select(x => x.Name).Distinct())
            {
                UpdateUsedCards(winner.UsedCards, cardName, true);
            }
        }

        private static void UpdateLoserUsedCards(Duel duel, IEnumerable<Card> usedCards, Player loser, PlayerConfiguration loserConfiguration)
        {
            ++loserConfiguration.Losses;
            foreach (string cardName in usedCards.Where(x => duel.GetOwner(x) == loser).Select(x => x.Name).Distinct())
            {
                UpdateUsedCards(loserConfiguration.UsedCards, cardName, false);
            }
        }

        private static void PlayRoundOfGames(Simulator simulator, SimulationConfiguration conf, List<MatchUp> matchUps)
        {
            foreach (var matchUp in matchUps)
            {
                PlayGame(matchUp, simulator, conf.SimulationDepth);
            }

            foreach (var group in matchUps.SelectMany(x => x.Players).GroupBy(x => x.Id))
            {
                Console.WriteLine(group.First());
            }
            Console.WriteLine();
            Dictionary<string, Tuple<int, int>> cards = new();
            foreach (var u in matchUps.SelectMany(x => x.Players).SelectMany(x => x.UsedCards))
            {
                if (cards.ContainsKey(u.Key))
                {
                    cards[u.Key] = new Tuple<int, int>(cards[u.Key].Item1 + u.Value.Item1, cards[u.Key].Item2 + u.Value.Item2);
                }
                else
                {
                    cards.Add(u.Key, u.Value);
                }
            }
            PrintCardStatistics(cards);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
        }

        static List<Card> GetCards(Guid player)
        {
            List<Card> cards = CardFactory.CreateAll().OrderBy(arg => Guid.NewGuid()).Take(40).ToList();
            foreach (var card in cards)
            {
                card.Owner = player;
            }
            return cards;
        }

        static List<Card> GetCards(Guid player, string path)
        {
            if (path == null)
            {
                return GetCards(player);
            }
            else
            {
                List<Card> cards = new();
                using var reader = XmlReader.Create(path);
                foreach (var card in (new XmlSerializer(typeof(DeckConfiguration)).Deserialize(reader) as DeckConfiguration).Sections.Single(x => x.Name == "Main").Cards)
                {
                    for (int i = 0; i < card.Quantity; ++i)
                    {
                        cards.Add(CreateCard(card.Name, player));
                    }
                }
                return cards;
            }
        }

        static Card CreateCard(string name, Guid player)
        {
            var card = CardFactory.Create(name);
            card.Owner = player;
            return card;
        }

        static void PrintCardStatistics(Dictionary<string, Tuple<int, int>> cards)
        {
            foreach (var c in cards.OrderByDescending(x => GetCardPoints(x.Value.Item1, x.Value.Item2)))
            {
                Console.WriteLine($"{c.Key} w{c.Value.Item1} l{c.Value.Item2} r{GetWinrate(c.Value.Item1, c.Value.Item2)} p{GetCardPoints(c.Value.Item1, c.Value.Item2)}");
            }
        }

        static void UpdateUsedCards(Dictionary<string, Tuple<int, int>> usedCards, string cardName, bool win)
        {
            if (usedCards.ContainsKey(cardName))
            {
                usedCards[cardName] = new Tuple<int, int>(usedCards[cardName].Item1 + (win ? 1 : 0), usedCards[cardName].Item2 + (win ? 0 : 1));
            }
            else
            {
                usedCards.Add(cardName, new Tuple<int, int>((win ? 1 : 0), (win ? 0 : 1)));
            }
        }

        public static double GetWinrate(int wins, int losses)
        {
            return Math.Round((double)wins / (wins + losses), 2);
        }

        static double GetCardPoints(double wins, double losses)
        {
            var rate = wins / (wins + losses);
            var fo = rate - (rate - 0.5) * Math.Pow(2, -1 * Math.Log10(wins + losses + 1));
            return Math.Round(fo, 2);
        }
    }
}
