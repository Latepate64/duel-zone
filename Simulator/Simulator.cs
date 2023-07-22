using Cards;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Simulator
{
    public class Simulator : ISimulator
    {
        private readonly ICardFactory _cardFactory;

        public Simulator(ICardFactory cardFactory)
        {
            _cardFactory = cardFactory;
        }

        public Game PlayDuel(Player player1, Player player2)
        {
            Game game = new();
            game.Play(player1, player2);
            return game;
        }

        public void PlayRoundOfGames(SimulationConfiguration conf, List<MatchUp> matchUps)
        {
            foreach (var matchUp in matchUps)
            {
                PlayGame(matchUp, this, conf.SimulationDepth);
            }
            //foreach (var group in matchUps.SelectMany(x => x.Players).GroupBy(x => x.Id))
            //{
            //    Console.WriteLine(group.First());
            //}
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
        }

        private void PlayGame(MatchUp matchUp, Simulator simulator, int simulationDepth)
        {
            using Player player1 = new SimulationPlayer { Name = matchUp.StartingPlayer.Name }, player2 = new SimulationPlayer { Name = matchUp.Opponent.Name };
            player1.Deck.Setup(GetCards(player1, matchUp.StartingPlayer.DeckPath), player1);
            player2.Deck.Setup(GetCards(player2, matchUp.Opponent.DeckPath), player2);
            using var game = simulator.PlayDuel(player1, player2);

            var usedCards = game.Turns.SelectMany(x => x.Phases).SelectMany(x => x.UsedCards);
            if (game.Winner != null)
            {
                UpdateWinnerUsedCards(game, usedCards, matchUp.Players.Distinct().Single(x => x.Name == game.Winner.Name));
            }
            foreach (var loser in game.Losers)
            {
                UpdateLoserUsedCards(game, usedCards, loser, matchUp.Players.Distinct().Single(x => x.Name == loser.Name));
            }
        }

        private static void UpdateWinnerUsedCards(Game game, IEnumerable<ICard> usedCards, PlayerConfiguration winner)
        {
            ++winner.Wins;
            //foreach (string cardName in usedCards.Where(x => game.GetOwner(x) == game.Winner).Select(x => x.Name).Distinct())
            //{
            //    UpdateUsedCards(winner.UsedCards, cardName, true);
            //}
        }

        private static void UpdateLoserUsedCards(Game game, IEnumerable<ICard> usedCards, IPlayer loser, PlayerConfiguration loserConfiguration)
        {
            ++loserConfiguration.Losses;
            //foreach (string cardName in usedCards.Where(x => game.GetOwner(x) == loser).Select(x => x.Name).Distinct())
            //{
            //    UpdateUsedCards(loserConfiguration.UsedCards, cardName, false);
            //}
        }

        private static List<Card> GetCards(IPlayer player)
        {
            var allCards = CardFactory.CreateAll().OrderBy(arg => Guid.NewGuid());
            var effects = CardFactory.CreateEffects().OrderBy(x => x.ToString());
            var oneShotEffects = effects.OfType<IOneShotEffect>().ToArray();
            var continuousEffects = effects.OfType<IContinuousEffect>().ToArray();
            var cardTexts = string.Join(Environment.NewLine, allCards.OrderBy(x => x.Name).Select(x => x.Name + ": " + string.Join("; ", x.PrintedAbilities.Select(x => x.ToString()))));
            var cards = allCards.Take(40).ToList();
            foreach (var card in cards)
            {
                card.Owner = player;
            }
            return cards;
        }

        private List<Card> GetCards(IPlayer player, string path)
        {
            if (path == null)
            {
                return GetCards(player);
            }
            else
            {
                int id = 0;
                List<Card> cards = new();
                using var reader = XmlReader.Create(path);
                foreach (var cardGroup in (new XmlSerializer(typeof(DeckConfiguration)).Deserialize(reader) as DeckConfiguration).Sections.Single(x => x.Name == "Main").Cards)
                {
                    for (int i = 0; i < cardGroup.Quantity; ++i)
                    {
                        Card card = CreateCard(cardGroup.Name, player);
                        card.PhysicalCardId = id++;
                        cards.Add(card);
                    }
                }
                return cards;
            }
        }

        private Card CreateCard(string name, IPlayer player)
        {
            var card = _cardFactory.Create(name);
            card.Owner = player;
            return card;
        }

        private static void PrintCardStatistics(Dictionary<string, Tuple<int, int>> cards)
        {
            foreach (var c in cards.OrderByDescending(x => GetCardPoints(x.Value.Item1, x.Value.Item2)))
            {
                Console.WriteLine($"{c.Key} w{c.Value.Item1} l{c.Value.Item2} r{GetWinrate(c.Value.Item1, c.Value.Item2)} p{GetCardPoints(c.Value.Item1, c.Value.Item2)}");
            }
        }

        public static double GetWinrate(int wins, int losses)
        {
            return Math.Round((double)wins / (wins + losses), 2);
        }

        private static double GetCardPoints(double wins, double losses)
        {
            var rate = wins / (wins + losses);
            var fo = rate - (rate - 0.5) * Math.Pow(2, -1 * Math.Log10(wins + losses + 1));
            return Math.Round(fo, 2);
        }
    }
}
